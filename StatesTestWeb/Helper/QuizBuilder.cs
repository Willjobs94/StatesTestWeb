using System;
using System.Collections.Generic;
using System.Linq;
using StatesTest.Data.Repositories;

namespace StatesTestWeb.Helper
{
    public class QuizBuilder
    {
        private readonly IStateRepository _stateRepository;
        
        private static Random rnd = new Random();

        public QuizBuilder(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        private Question BuildStateQuestion()
        {
            var question = new Question();

            var states = _stateRepository.GetAll().ToList();
            var allChoices = states.Select(x => x.Capital).ToList();
            var r = rnd.Next(states.Count);

            var answerState = states[r];

            question.CorrectAnswer = answerState.Capital;
            question.Title = $"¿Cuál es la capital de {answerState.StateName}?";
            question.CorrectStateId = answerState.StateId;
            
            var choices = new List<string> {answerState.Capital};

            //Make sure there are not repeated choices on the question
            while (choices.Count != 4)
            { 
                var randomChoice = allChoices[rnd.Next(allChoices.Count)];
                if(choices.All(x => x != randomChoice))
                {
                    choices.Add(randomChoice);
                }
            }
            
            question.Choices = choices;
            
            return question;

        }
        
        public List<Question> GetQuestions(int questionsAmount = 10)
        {
            var questionList = new List<Question>();

            while (questionList.Count != questionsAmount)
            {
                var question = BuildStateQuestion();
                //Make sure there are not repeated questions on the quiz
                if (questionList.All(x => x.CorrectStateId != question.CorrectStateId))
                {
                    questionList.Add(question);
                }
            }
            
            return questionList;
        }
    }

    public class Question
    {
        public string Title { get; set; }
        public List<string> Choices { get; set; }
        public string CorrectAnswer { get; set; }
        
        public int CorrectStateId { get; set; }
    }
}