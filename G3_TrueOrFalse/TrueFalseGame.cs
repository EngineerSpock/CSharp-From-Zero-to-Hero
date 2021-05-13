using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TrueOrFalse
{
    public class TrueFalseGame
    {
        private readonly int allowedMistakes;

        public event EventHandler<GameResultEventArgs> EndOfGame; 
        
        public GameStatus GameStatus { get; private set; }

        private int counter;
        private readonly List<Question> questions = new List<Question>();

        public TrueFalseGame(string filePath, int allowedMistakes)
        {
            this.allowedMistakes = allowedMistakes;

            var questions = File.ReadAllLines(filePath).Select(x =>
            {
                string[] parts = x.Split(';');
                string text = parts[0];
                bool correctAnswer = parts[1] == "Yes";
                string explanation = parts[2];
                
                return new Question(text, correctAnswer, explanation);
            });
            this.questions.AddRange(questions);

            GameStatus = GameStatus.InProgress;
        }

        public Question GetNextQuestion()
        {
            return questions[counter];
        }

        private int mistakes;
        public void GiveAnswer(bool answer)
        {
            if (!questions[counter].CorrectAnswer == answer)
            {
                mistakes++;
            }
            
            if (counter == questions.Count - 1 || mistakes > allowedMistakes)
            {
                GameStatus = GameStatus.GameIsOver;
                if (EndOfGame != null)
                    EndOfGame(this, new GameResultEventArgs(counter, mistakes, mistakes <= allowedMistakes));
            }

            counter++;
        }
    }
}