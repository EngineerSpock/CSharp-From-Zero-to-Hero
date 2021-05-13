using System;

namespace TrueOrFalse
{
    public class GameResultEventArgs : EventArgs
    {
        public int QuestionsPassed { get; }
        public int MistakesMade { get; }
        public bool IsWin { get; }

        public GameResultEventArgs(int questionsPassed, int mistakesMade, bool isWin)
        {
            QuestionsPassed = questionsPassed;
            MistakesMade = mistakesMade;
            IsWin = isWin;
        }
    }
}