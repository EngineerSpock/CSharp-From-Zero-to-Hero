using System;

namespace TrueOrFalse
{  
    public class Question
    {
        public string Text { get; }
        public bool CorrectAnswer { get; }
        public string Explanation { get; }

        public Question(string text, bool correctAnswer, string explanation)
        {
            Text = text;
            CorrectAnswer = correctAnswer;
            Explanation = explanation;
        }
    }
}