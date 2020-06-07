using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamResultsLister.Models;
using ExamResultsLister.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExamResultsLister.Controllers
{
    /// <summary>
    /// ExamResults Control that handles ExamResults Operations
    /// </summary>
    [ApiController]
    [Route("[controller]")]    
    public class ExamResultsController : ControllerBase
    {
        private readonly ILogger<ExamResultsController> _logger;
        private readonly IExamAPIService _examAPIService;

        public ExamResultsController(ILogger<ExamResultsController> logger,
                                     IExamAPIService examAPIService)
        {
            _logger = logger;
            _examAPIService = examAPIService;
        }

        /// <summary>
        /// Returns List of ExamResults
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ExamResultsViewModel>> Get()
        {
            var examResults = await _examAPIService.GetExamResults();

            if(examResults == null)
            {
                _logger.LogInformation($"Exam Result list is empty");
                return new List<ExamResultsViewModel>();
            }

            // Business Logic here
            // Linq code is split into 3 main section for easy reference
            var results = examResults.Where(es => es.Results.Any(r => r.Grade == GradeType.Pass))
                                    .Select(es => new
                                    {
                                        Subject = es.Subject,
                                        Results = es.Results.Where(r => r.Grade == GradeType.Pass)
                                    });
            
            var filteredResults = results.Select(s => new
            {
                Subject = s.Subject,
                Year = s.Results.FirstOrDefault().Year
            });

            var groupedResults = filteredResults.GroupBy(s => s.Year)
                                                .OrderBy(s => s.Key)
                                                .Select(s => new ExamResultsViewModel()
                                                 {
                                                     Year = s.Key,
                                                     Subjects = s.Select(s => s.Subject)
                                                                 .OrderBy(s => s)
                                                                 .ToArray<string>()
                                                 });
            
            return groupedResults;
        }
    }
}
