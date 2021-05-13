using System;

namespace SticksGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new SticksGame(10, Player.Human);
            game.MachinePlayed += MachinePlayed;
            game.HumanTurnToMakeMove += GameOnHumanTurnToMakeMove;
            game.EndOfGame += EndOfGameHandler;
            
            game.Start();
        }
        
        private static void GameOnHumanTurnToMakeMove(object sender, int remainingSticks)
        {
            Console.WriteLine($"Remaining sticks: {remainingSticks}");
            Console.WriteLine("Take some sticks.");

            bool takenCorrectly = false;
            while (!takenCorrectly)
            {
                if (int.TryParse(Console.ReadLine(), out int takenSticks))
                {
                    var game = (SticksGame) sender;

                    try
                    {
                        game.HumanTakes(takenSticks);
                        takenCorrectly = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }    
            }
        }

        private static void EndOfGameHandler(object sender, GameOverEventArgs e)
        {
            Console.WriteLine($"Winner: {e.WinningPlayer}");
        }

        private static void MachinePlayed(object sender, int sticksTaken)
        {
            Console.WriteLine($"Machine took:{sticksTaken}");
        }
    }
}