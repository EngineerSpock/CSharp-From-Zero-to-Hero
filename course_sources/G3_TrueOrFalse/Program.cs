using System;
using System.Net;

namespace TrueOrFalse
{
    class Program
    {
        static void Main(string[] args)
        {
            TrueFalseGame game = new TrueFalseGame("Questions.txt", 1);
            game.EndOfGame += (sender, eventArgs) =>
            {
                Console.WriteLine($"Questions asked:{eventArgs.QuestionsPassed}. Mistakes made:{eventArgs.MistakesMade}.");
                Console.WriteLine(eventArgs.IsWin ? "You won!" : "You lost!");
            };

            while (game.GameStatus == GameStatus.InProgress)
            {
                Question q = game.GetNextQuestion();
                Console.WriteLine("Do you believe in the next statement or question? Enter 'y' or 'n'");
                Console.WriteLine(q.Text);

                string answer = Console.ReadLine();
                bool boolAnswer = answer == "y";

                if (q.CorrectAnswer == boolAnswer)
                {
                    Console.WriteLine("Good job. You're right!");
                }
                else
                {
                    Console.WriteLine("Ooops, actually you're mistaken. Here is the commentary:");
                    Console.WriteLine($"{q.Explanation}");
                }
                
                game.GiveAnswer(boolAnswer);
            }
            
            Console.ReadLine();
        }

       
    }
}
