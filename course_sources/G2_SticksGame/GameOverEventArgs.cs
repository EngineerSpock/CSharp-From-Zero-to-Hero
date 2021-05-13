using System;

namespace SticksGame
{
    public class GameOverEventArgs : EventArgs
    {
        public Player WinningPlayer { get; }

        public GameOverEventArgs(Player winningPlayer)
        {
            WinningPlayer = winningPlayer;
        }
    }
}