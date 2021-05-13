using System;

namespace D_OOP.Homeworks
{
    public enum GuessingPlayer
    {
        Human,
        Machine
    }

    public class GuessNumberGame
    {
        private readonly int max;
        private readonly int maxTries;
        private readonly GuessingPlayer guessingPlayer;

        public GuessNumberGame(int max = 100, int maxTries = 5, GuessingPlayer guessingPlayer = GuessingPlayer.Human)
        {
            this.max = max;
            this.maxTries = maxTries;
            this.guessingPlayer = guessingPlayer;
        }

        public void Start()
        {
            if(guessingPlayer == GuessingPlayer.Human)
            {
                HumanGuesses();
            }
            else
            {
                MachineGuesses();
            }
        }

        private void MachineGuesses()
        {
            Console.WriteLine("Enter a number that's going to be guessed by a computer.");

            int guessedNumber = -1;
            while(guessedNumber == -1)
            {
                int parsednumber = int.Parse(Console.ReadLine());
                if (parsednumber >= 0 && parsednumber <= this.max)
                {
                    guessedNumber = parsednumber;
                }
            }

            int lastGuess = -1;
            int min = 0;
            int max = this.max;
            int tries = 0;
            while (lastGuess != guessedNumber && tries < maxTries)
            {
                lastGuess = (max + min) / 2;
                Console.WriteLine($"Did you guess this number - {lastGuess}?");
                Console.WriteLine("If yes - enter 'y', if your number is greater - enter 'g', if less - enter 'l'");

                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.WriteLine("Super! I guessed your number, man!");
                    break;
                }
                else if(answer == "g")
                {
                    min = lastGuess;
                }
                else
                {
                    max = lastGuess;
                }

                if(lastGuess == guessedNumber)
                {
                    Console.WriteLine("Don't cheat, man!");
                }
                tries++;
                if (tries == maxTries)
                {
                    Console.WriteLine("No tries anymore :( I lost!");
                }
            }
        }

        private void HumanGuesses()
        {
            Random rand = new Random();
            int guessedNumber = rand.Next(0, max);

            int lastGuess = -1;
            int tries = 0;
            while (lastGuess != guessedNumber && tries < maxTries)
            {
                Console.WriteLine("Guess the number!");
                lastGuess = int.Parse(Console.ReadLine());

                if(lastGuess == guessedNumber)
                {
                    Console.WriteLine("You guessed the number!");
                    break;
                }
                else if(lastGuess < guessedNumber)
                {
                    Console.WriteLine("My number is greater!");
                }
                else
                {
                    Console.WriteLine("My number is less!");
                }
                tries++;

                if (tries == maxTries)
                {
                    Console.WriteLine("You lost!");
                }
            }            
        }
    }
}
