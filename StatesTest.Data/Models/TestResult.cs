using System;
using System.ComponentModel.DataAnnotations;

namespace StatesTest.Data.Models
{
    public class TestResult
    {
        /// <summary>
        /// Autonumber primary key field
        /// </summary>
        [Key]
        public int TestResultId { get; set; }
        /// <summary>
        /// The date and time that the results are recorded in the database
        /// </summary>
        public DateTime TestDateTime { get; set; }
        /// <summary>
        /// The number of questions presented on the test
        /// </summary>
        public int TotalQuestions { get; set; }
        /// <summary>
        /// The number of correct answers to the State/Capital quiz
        /// </summary>
        public int NumberCorrect  { get; set; }
        /// <summary>
        /// Navigation Property of User
        /// </summary>
        public User User { get; set; }
    }
}
