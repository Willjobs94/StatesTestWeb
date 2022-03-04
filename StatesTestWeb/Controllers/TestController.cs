using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StatesTestWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using StatesTestWeb.Helper;
using StatesTest.Data.Repositories;
using AutoMapper;
using StatesTest.Data.Models;
using StatesTest.Data;
using Microsoft.AspNetCore.Authorization;

namespace StatesTestWeb.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly QuizBuilder _quizBuilder;
        private readonly ITestResultRepository _testResultRepository;
        private readonly IMapper _objectMapper;
        private readonly int _loggedUserId = 0;
        private readonly ICurrentUserService _currentUserService;
        

        public TestController(ILogger<TestController> logger, QuizBuilder quizBuilder, ITestResultRepository testResultRepository, IMapper objectMapper, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _quizBuilder = quizBuilder;
            _testResultRepository = testResultRepository;
            _objectMapper = objectMapper;
            _currentUserService = currentUserService;
        }


        public List<Question> GetQuestions()
        {
            var questions = _quizBuilder.GetQuestions();
            return questions;
        }

        public async Task<TestResultItemOutputDto> SaveTestResult([FromBody] CreateTestResultInputDto input)
        {
            var currentUserId = _currentUserService.UserId;

            var entity = _objectMapper.Map<TestResult>(input);
            entity.TestDateTime = DateTime.Now;
            entity.UserId = currentUserId;

            var savedEntity = await _testResultRepository.Create(entity);

            var result = new TestResultItemOutputDto
            {
                TestDate = savedEntity.TestDateTime,
                CorrectAnswers = savedEntity.NumberCorrect,
                NumberOfQuestions = savedEntity.TotalQuestions,
                TestResultId = savedEntity.TestResultId,
                Score = savedEntity.NumberCorrect
            };

            return result;
        }


        public List<TestResultItemOutputDto> GetAll()
        {

            //_ = int.TryParse(User.FindFirst("UserId").Value, out var loggedUserId)
            //
            var currentUserId = _currentUserService.UserId;;

            var result = _testResultRepository.GetAll().Where(x => x.UserId == currentUserId).Select(x => new TestResultItemOutputDto
            {
                TestDate = x.TestDateTime,
                CorrectAnswers = x.NumberCorrect,
                NumberOfQuestions = x.TotalQuestions,
                TestResultId = x.TestResultId,
                Score = x.NumberCorrect
            }).OrderByDescending(x => x.TestDate).ToList();

            return result;

        }
    }
}
