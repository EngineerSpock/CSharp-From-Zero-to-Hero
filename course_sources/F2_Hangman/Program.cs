using System;
using System.IO;
using System.Text;

namespace Hangman
{
    //todo also can deprecate letter repetition
    //also can display already tried letters

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            int lettersCount = game.GenerateWord();
            Console.WriteLine($"The word consists of {lettersCount} letters");
            Console.WriteLine("Try to guess the word.");

            while (game.GameStatus == GameStatus.InProgress)
            {
                Console.WriteLine("Pick a letter");
                char c = Console.ReadLine().ToCharArray()[0];

                string curState = game.GuessLetter(c);
                Console.WriteLine(curState);

                Console.WriteLine($"Remaining tries = {game.RemainingTries}");
                Console.WriteLine($"Tried letters:{game.TriedLetters}");
            }
            if (game.GameStatus == GameStatus.Lost)
            {
                Console.WriteLine("You lost.");
                Console.WriteLine($"The word was: {game.Word}");
            }
            if (game.GameStatus == GameStatus.Won)
            {
                Console.WriteLine("You won!");
            }
            Console.ReadLine();
        }
    }

//    public class Game
//    {
//        private readonly int allowedMisses;
//        private bool[] openIndexes;
//        private int counter = 0;
//        private string triedLetters;
//
//        public int RemainingTries
//        {
//            get
//            {
//                return allowedMisses - counter;
//            }
//        }
//
//        public string TriedLetters
//        {
//            get
//            {
//                var chars = triedLetters.ToCharArray();
//                Array.Sort(chars);
//                return new string(chars);
//            }
//        }
//
//        public Game(int allowedMisses = 6)
//        {
//            if (allowedMisses < 5 || allowedMisses > 8)
//            {
//                throw new ArgumentException("Number of allowed misses should be between 5 and 8.");
//            }
//
//            this.allowedMisses = allowedMisses;
//        }
//
//        public GameStatus GameStatus { get; private set; } = GameStatus.NotStarted;
//        public string Word { get; private set; }
//
//        public int GenerateWord()
//        {
//            //string[] words = File.ReadAllLines("WordsStockRus.txt", Encoding.GetEncoding(1251));
//            string[] words = File.ReadAllLines("WordsStockRus.txt");
//            Random r = new Random(DateTime.Now.Millisecond);
//            int randIndex = r.Next(words.Length - 1);
//
//            Word = words[randIndex];
//
//            openIndexes = new bool[Word.Length];
//            //for (int i = 0; i < openIndexes.Length; i++)
//            //{
//            //    openIndexes[i] = -1;
//            //}
//
//            GameStatus = GameStatus.InProgress;
//
//            return Word.Length;
//        }
//
//        public string GuessLetter(char letter)
//        {
//            if (counter == allowedMisses)
//            {
//                throw new InvalidOperationException($"Exceeded the max misses number: {allowedMisses}");
//            }
//            if (GameStatus != GameStatus.InProgress)
//            {
//                throw new InvalidOperationException($"Inaproppriate status of game:{GameStatus}");
//            }
//
//            bool openAny = false;
//            
//            string result = string.Empty;
//            for (int i = 0; i < Word.Length; i++)
//            {
//                if (Word[i] == letter)
//                {
//                    openIndexes[i] = true;
//                    openAny = true;
//                }
//
//                if (openIndexes[i])
//                {
//                    result += Word[i];
//                }
//                else
//                {
//                    result += "-";
//                }
//            }
//            if (!openAny)
//                counter++;
//
//            triedLetters += letter;
//
//            if (IsWin())
//                GameStatus = GameStatus.Won;
//            else if (counter == allowedMisses)
//            {
//                GameStatus = GameStatus.Lost;
//            }
//
//            return result;
//        }
//
//        private bool IsWin()
//        {
//            foreach (var cur in openIndexes)
//            {
//                if (cur == false)
//                    return false;
//            }
//            return true;
//        }
//
//    }

    public enum GameStatus
    {
        Won,
        Lost,
        InProgress,
        NotStarted
    }
}
