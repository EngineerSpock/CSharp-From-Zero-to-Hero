using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MasterLinq
{
    public class ParseCsvDemo
    {
        private static int _count;

        public static void Run()
        {
            //SkipWhile();
            //TakeWhile();

            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");
            DefaultIfEmptyDemo(fileLocation);
            //MinMaxSumAverage(fileLocation);
            //SequenceEqual(fileLocation);
            //ParseCsv(fileLocation);
            //Demo(fileLocation);
        }

        public static void MinMaxSumAverageNew(string file)
        {            
            _count = 1;
            var list = File.ReadAllLines(file)
                .Skip(_count)
                .Select(ChessPlayer.ParseFideCsv)
                .Where(delegate(ChessPlayer p) { return p.BirthYear > 1988; })
                .OrderByDescending(player => player.Rating)
                .Take(10)
                .ToList();

            Console.WriteLine($"The lowest rating in TOP 10 : {list.Min(x => x.Rating)}");

            Console.WriteLine($"The highest rating in TOP 10 : {list.Max(x => x.Rating)}");
            Console.WriteLine($"The average rating in TOP 10 : {list.Average(x => x.Rating)}");
        }

        public static void SequenceEqual(string file)
        {
            var list = File.ReadAllLines(file)
                .Skip(1)
                .Select(ChessPlayer.ParseFideCsv)
                .Where(player => player.BirthYear > 1988)
                .Take(10).ToList();

            var list2 = File.ReadAllLines(file)
                .Skip(1)
                .Select(ChessPlayer.ParseFideCsv)
                .Where(player => player.BirthYear > 1988)
                .Take(10).ToList();

            var areEqual = list.SequenceEqual(list2, new PlayersComparer());
            Console.WriteLine($"Are collections equal={areEqual}");
        }

        public static void SkipWhile()
        {
            var intList = new[] {1, 2, 3, 4, 5, 3, 2, 4, 5};
            Console.WriteLine("Where");
            foreach (var i in intList.Where(x => x > 3)) Console.WriteLine(i);

            Console.WriteLine("SkipWhile");
            foreach (var i in intList.SkipWhile(x => x <= 3)) Console.WriteLine(i);
        }

        public static void TakeWhile()
        {
            var intList = new[] {1, 2, 3, 4, 2, 1};
            Console.WriteLine("Where");
            foreach (var i in intList.Where(x => x <= 3)) Console.WriteLine(i);

            Console.WriteLine("TakeWhile");
            foreach (var i in intList.TakeWhile(x => x <= 3)) Console.WriteLine(i);
        }


        public static void Demo(string file)
        {
            var list = File.ReadAllLines(file)
                .Skip(1)
                .Select(ChessPlayer.ParseFideCsv)
                .Where(player => player.BirthYear > 1988)
                .OrderByDescending(player => player.Rating)
                .ThenBy(p => p.Country)
                .Take(10);

            Console.WriteLine(list.First());
            Console.WriteLine(list.Last());

            Console.WriteLine(list.First(p => p.Country == "USA"));
            Console.WriteLine(list.Last(p => p.Country == "USA"));

            //var firstFromBra = list.First(p => p.Country == "BRA");
            var firstFromBra = list.FirstOrDefault(p => p.Country == "BRA");
            var lastFromBra = list.LastOrDefault(p => p.Country == "BRA");

            //var singleFromUS = list.Single(p => p.Country == "USA");
            //var singleFromUS = list.SingleOrDefault(p => p.Country == "USA");

            Console.WriteLine(list.Single(p => p.Country == "FRA"));
            Console.WriteLine(list.SingleOrDefault(p => p.Country == "BRA"));
        }

        public static void DefaultIfEmptyDemo(string file)
        {
            string[] cars =
            {
                "Alfa Romeo", "Aston Martin", "Audi", "Nissan", "Chevrolet", "Chrysler", "Dodge", "BMW",
                "Ferrari", "Bentley", "Ford", "Lexus", "Mercedes", "Toyota", "Volvo", "Subaru"
            };
            try
            {
                var nissan = cars.First(n => n.Equals("Porshe"));

                if (nissan != null)
                    Console.WriteLine("Автомобиль Porshe найден");
                else
                    Console.WriteLine("Автомобиль Porshe не найден");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var nissan2 = cars.Where(n => n.Equals("Porshe")).DefaultIfEmpty("default").First();
            Console.WriteLine(nissan2);

            string[] names = {"Bob", "Mary"};

            var result1 = names.FirstOrDefault(name => name.Length > 5);
            var result2 = names.DefaultIfEmpty("default").First(name => name.Length > 5);

            Console.WriteLine($"Result1:{result1}, Result2:{result2}");
        }

        public static void ParseCsv(string file)
        {
            var list = File.ReadAllLines(file)
                .Skip(1)
                .Select(s => ChessPlayer.ParseFideCsv(s))
                .Where(player => player.BirthYear > 1988)
                .OrderByDescending(player => player.Rating)
                .ThenBy(p => p.Country)
                .Take(10);

            foreach (var player in list) Console.WriteLine(player);
        }

        private static IOrderedEnumerable<ChessPlayer> QuerySyntax(IEnumerable<ChessPlayer> list)
        {
            var filtered2 = from player in list
                where player.BirthYear > 1988
                orderby player.Rating descending
                select player;
            return filtered2;
        }

        public static void DemoDistinct()
        {
            Console.WriteLine("Full demo list of CHess Players:\n");
            foreach (var player in ChessPlayer.GetDemoList()) Console.WriteLine(player);

            Console.WriteLine("\nCustom Disctinct\n");

            var discinctByRating = ChessPlayer.GetDemoList().Distinct(new DistinctComparer());
            foreach (var player in discinctByRating) Console.WriteLine(player);
            //string str = "Hello, World";

            //Console.WriteLine("\"Hello, World\" contains the following chars:");
            //foreach (var c in str.ToCharArray().Distinct())
            //{
            //    Console.Write(c);
            //}

            //Console.WriteLine("\n");
        }
    }

    public class DistinctComparer : IEqualityComparer<ChessPlayer>
    {
        public bool Equals(ChessPlayer x, ChessPlayer y)
        {
            return x.Rating == y.Rating;
        }

        public int GetHashCode(ChessPlayer obj)
        {
            return obj.Rating.GetHashCode();
        }
    }
}