using ExamResultsLister.Controllers;
using ExamResultsLister.Models;
using ExamResultsLister.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamResultsLister.Test
{
    public class ExamResultsControllerTest
    {
        private ExamResultsController resultsController;
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
                            Grade = GradeType.Fail,
                            Year = 2019
                        },
                        new Results()
                        {
                            Grade = GradeType.Pass,
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
                            Grade = GradeType.Pass,
                            Year = 2019
                        }
                    }
                }
            };

            var logger = new Mock<ILogger<ExamResultsController>>();
            var examAPIService = new Mock<IExamAPIService>();
            examAPIService.Setup(p => p.GetExamResults())
                          .Returns(Task.FromResult(examSubjects));

            resultsController = new ExamResultsController(logger.Object, examAPIService.Object);
        }

        [Test]
        public async Task GetExamResults_Return_Expected_Object_Type()
        {
            // Arrange
            // Act
            var results = await resultsController.Get();
            var resultsList = results.ToList();
            // Assert
            Assert.That(resultsList, Is.InstanceOf(typeof(List<ExamResultsViewModel>)));
        }


        [Test]
        public async Task GetExamResults_Return_Expected_Results()
        {
            // Arrange
            // Act
            var results = await resultsController.Get();

            // Assert
            Assert.IsTrue(results.Count()==2);
            Assert.IsTrue(results.FirstOrDefault().Year == 2019);
            Assert.IsTrue(results.FirstOrDefault().Subjects[0].Equals("B Test Subject Two", System.StringComparison.OrdinalIgnoreCase));
        }

        [Test]
        public async Task GetExamResults_Return_Empty_Results()
        {
            // Arrange
            var logger = new Mock<ILogger<ExamResultsController>>();
            var examAPIService = new Mock<IExamAPIService>();
            examAPIService.Setup(p => p.GetExamResults())
                          .Returns(Task.FromResult(new List<ExamSubject>()));

            resultsController = new ExamResultsController(logger.Object, examAPIService.Object);

            // Act
            var results = await resultsController.Get();

            // Assert
            Assert.IsTrue(results.Count() == 0);
        }
    }
}