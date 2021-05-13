using System;
using System.IO;

namespace Hangman
{
    public class Game
    {
        private readonly int allowedMisses;
        private bool[] openIndexes;
        private int counter = 0;
        private string triedLetters;

        public int RemainingTries
        {
            get
            {
                return allowedMisses - counter;
            }
        }

        public string TriedLetters
        {
            get
            {
                var chars = triedLetters.ToCharArray();
                Array.Sort(chars);
                return new string(chars);
            }
        }

        public Game(int allowedMisses = 6)
        {
            if (allowedMisses < 5 || allowedMisses > 8)
            {
                throw new ArgumentException("Number of allowed misses should be between 5 and 8.");
            }

            this.allowedMisses = allowedMisses;
        }

        public GameStatus GameStatus { get; private set; } = GameStatus.NotStarted;
        public string Word { get; private set; }

        public int GenerateWord()
        {
            //string[] words = File.ReadAllLines("WordsStockRus.txt", Encoding.GetEncoding(1251));
            string[] words = File.ReadAllLines("WordsStockRus.txt");
            Random r = new Random(DateTime.Now.Millisecond);
            int randIndex = r.Next(words.Length - 1);

            Word = words[randIndex];

            openIndexes = new bool[Word.Length];
            //for (int i = 0; i < openIndexes.Length; i++)
            //{
            //    openIndexes[i] = -1;
            //}

            GameStatus = GameStatus.InProgress;

            return Word.Length;
        }

        public string GuessLetter(char letter)
        {
            if (counter == allowedMisses)
            {
                throw new InvalidOperationException($"Exceeded the max misses number: {allowedMisses}");
            }
            if (GameStatus != GameStatus.InProgress)
            {
                throw new InvalidOperationException($"Inaproppriate status of game:{GameStatus}");
            }

            bool openAny = false;
            
            string result = string.Empty;
            for (int i = 0; i < Word.Length; i++)
            {
                if (Word[i] == letter)
                {
                    openIndexes[i] = true;
                    openAny = true;
                }

                if (openIndexes[i])
                {
                    result += Word[i];
                }
                else
                {
                    result += "-";
                }
            }
            if (!openAny)
                counter++;

            triedLetters += letter;

            if (IsWin())
                GameStatus = GameStatus.Won;
            else if (counter == allowedMisses)
            {
                GameStatus = GameStatus.Lost;
            }

            return result;
        }

        private bool IsWin()
        {
            foreach (var cur in openIndexes)
            {
                if (cur == false)
                    return false;
            }
            return true;
        }

    }
}