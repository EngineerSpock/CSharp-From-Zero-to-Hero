using System;

namespace SticksGame
{
    public class SticksGame
    {
        private readonly Random randomizer;
        public int InitialSticksNumber { get; }
        public Player Turn { get; private set; }
        
        public int RemainingSticks { get; private set; }

        public event EventHandler<GameOverEventArgs> EndOfGame;
        public event EventHandler<int> MachinePlayed;
        public event EventHandler<int> HumanTurnToMakeMove;
        
        public GameStatus GameStatus { get; private set; }

        public SticksGame(int initialSticksNumber, Player whoMakesFirstMove)
        {
            if (initialSticksNumber < 7 || initialSticksNumber > 30)
            {
                throw new ArgumentException("Initial number of sticks should be >= 7 and <= 30");
            }
            
            randomizer = new Random();
            GameStatus = GameStatus.NotStarted;
            InitialSticksNumber = initialSticksNumber;
            RemainingSticks = InitialSticksNumber;
            Turn = whoMakesFirstMove;
        }
        
        
        public void HumanTakes(int sticks)
        {
            if (sticks < 1 || sticks > 3)
            {
                throw new ArgumentException("You can take from 1 to 3 sticks in a single move.");
            }

            if (sticks > RemainingSticks)
            {
                throw new ArgumentException($"You can't take more than remaining. Remains:{RemainingSticks}");
            }

            TakeSticks(sticks);
        }

        public void Start()
        {
            if (GameStatus == GameStatus.GameIsOver)
            {
                RemainingSticks = InitialSticksNumber;
            }

            if (GameStatus == GameStatus.InProgress)
            {
                throw new InvalidOperationException("Can't call Start when game is already in progress.");   
            }
            
            GameStatus = GameStatus.InProgress;
            while (GameStatus == GameStatus.InProgress)
            {
                if (Turn == Player.Computer)
                {
                    CompMakesMove();
                }
                else
                {
                    HumanMakesMove();
                }
                
                FireEndOfGameIfRequired();
                
                Turn = Turn == Player.Computer ? Player.Human : Player.Computer;
                
            }
            
        }

        private void HumanMakesMove()
        {
            if (HumanTurnToMakeMove != null)
            {
                HumanTurnToMakeMove(this, RemainingSticks);
            }
        }

        private void CompMakesMove()
        {
            int maxNumber = RemainingSticks >= 3 ? 3 : RemainingSticks;
            int sticks = randomizer.Next(1, maxNumber);
            
            TakeSticks(sticks);
            if (MachinePlayed != null)
                MachinePlayed(this, sticks);
        }

        private void FireEndOfGameIfRequired()
        {
            if (RemainingSticks == 0)
            {
                GameStatus = GameStatus.GameIsOver;
                if (EndOfGame != null)
                    EndOfGame(this, new GameOverEventArgs(Turn == Player.Computer ? Player.Human : Player.Computer));
            }
        }

        private void TakeSticks(int sticks)
        {
            RemainingSticks -= sticks;
        }

    }
}