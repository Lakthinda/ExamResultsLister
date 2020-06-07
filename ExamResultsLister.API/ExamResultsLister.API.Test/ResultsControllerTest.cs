using ExamResultsLister.API.Controllers;
using ExamResultsLister.API.Models;
using ExamResultsLister.API.Services;
using ExamResultsLister.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamResultsLister.Test
{
    public class ResultsControllerTest
    {
        private ResultsController resultsController;
        [SetUp]
        public void Setup()
        {
            List<ExamSubject> examSubjects = new List<ExamSubject>
            {
                new ExamSubject()
                {
                    Subject = "A Test Subject One",
                    Results = new List<Results>
                    {
                        new Results()
                        {
                            Grade = "FAIL",
                            Year = 2019
                        },
                        new Results()
                        {
                            Grade = "PASS",
                            Year = 2020
                        }
                    }
                },
                new ExamSubject()
                {
                    Subject = "B Test Subject Two",
                    Results = new List<Results>
                    {
                        new Results()
                        {
                            Grade = "Pass",
                            Year = 2019
                        }
                    }
                }
            };

            var logger = new Mock<ILogger<ResultsController>>();
            var examAPIService = new Mock<IExamRepositoryService>();
            examAPIService.Setup(p => p.GetExamResults())
                          .Returns(Task.FromResult(examSubjects));

            resultsController = new ResultsController(logger.Object, examAPIService.Object);
        }

        [Test]
        public async Task GetExamResults_Return_Expected_Object_Type()
        {
            // Arrange
            // Act
            var results = await resultsController.Get();
                        
            // Assert
            Assert.IsInstanceOf<OkObjectResult>(results);
            var okObjectResult = results as OkObjectResult;
            
            Assert.True(okObjectResult != null);
            var okResult = okObjectResult.Value as List<ExamSubjectViewModel>;
            Assert.True(okResult.Count() == 2);
        }

    }
}