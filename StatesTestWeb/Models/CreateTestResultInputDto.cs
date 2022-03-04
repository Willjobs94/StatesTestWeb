using Newtonsoft.Json;

namespace StatesTestWeb.Models
{
    public class CreateTestResultInputDto
    {
        /// <summary>
        /// The number of questions presented on the test
        /// </summary>
        [JsonProperty("totalQuestions")]
        public int TotalQuestions { get; set; }
        /// <summary>
        /// The number of correct answers to the State/Capital quiz
        /// </summary>
        [JsonProperty("numberCorrect")]
        public int NumberCorrect { get; set; }
    }
}
