using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingSystem.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public int NumberOfCorrectAnswers { get; set; }
        public List<Answer> PossibleAnswers { get; set; }
        public List<Answer> CorrectAnswers { get; set; }
        public int Points { get; set; }
        public string Explanation { get; set; }

        public int ThematicFieldId { get; set; }
        public virtual ThematicField Field { get; set; }
    }
}