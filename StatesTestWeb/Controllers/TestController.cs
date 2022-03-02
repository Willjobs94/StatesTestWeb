using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StatesTestWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using StatesTestWeb.Helper;

namespace StatesTestWeb.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly QuizBuilder _quizBuilder;
        
        public TestController(ILogger<TestController> logger, QuizBuilder quizBuilder)
        {
            _logger = logger;
            _quizBuilder = quizBuilder;
        }

        // [HttpGet("GetQuestions")]
        
        public List<Question> GetQuestions()
        {
            var questions = _quizBuilder.GetQuestions();
            return questions;
        }

    }
}
