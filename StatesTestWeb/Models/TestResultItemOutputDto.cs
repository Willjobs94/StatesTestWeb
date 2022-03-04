using System;

namespace StatesTestWeb.Models
{
    public class TestResultItemOutputDto
    {
        public int TestResultId { get; set; }
        public DateTime TestDate { get; set; }
        public int NumberOfQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int Score { get; set; }
    }
}
