using MasterLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Delegation
{
    //use to explain why we need lambdas and extention methods
    public class WhyLinq
    {
        public static void Demo()
        {
            var location = Path.Combine(Directory.GetCurrentDirectory(), "StudentStats");
            DisplayLargestStatFilesWithoutLinq(location);

            Console.WriteLine();

            DisplayLargestStaFilesWithLinq(location);

        }

        private static void DisplayLargestStaFilesWithLinq(string path)
        {
            new DirectoryInfo(path)
                .GetFiles()
                .Filter(file => file.LastWriteTime < new DateTime(2018, 08, 01))
                //.Where(file => file.LastWriteTime < new DateTime(2018, 08, 01))
                .OrderBy(KeySelector)
                .Take(5)
                .ForEach(file => Console.WriteLine($"{file.Name} weights {file.Length}"));

            //foreach (var file in files)
            //{
            //    Console.WriteLine($"{file.Name} weights {file.Length}");
            //}
        }

        private static long KeySelector(FileInfo file)
        {
            return file.Length;
        }

        private static void DisplayLargestStatFilesWithoutLinq(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            FileInfo[] files = dirInfo.GetFiles();
            Array.Sort(files, Comparison);

            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name} weights {file.Length}");
            }
        }

        private static int Comparison(FileInfo x, FileInfo y)
        {
            if (x.Length == y.Length) return 0;
            if (x.Length > y.Length) return 1;
            return -1;
        }
    }
}
