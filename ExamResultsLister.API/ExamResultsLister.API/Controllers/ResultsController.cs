using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExamResultsLister.API.Services;
using ExamResultsLister.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExamResultsLister.API.Controllers
{
    /// <summary>
    /// ExamResults Control that handles ExamResults Operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]    
    public class ResultsController : ControllerBase
    {
        private readonly ILogger<ResultsController> _logger;
        private readonly IExamRepositoryService _examRepository;

        public ResultsController(ILogger<ResultsController> logger,
                                IExamRepositoryService examRepositoryService)
        {
            _logger = logger;
            _examRepository = examRepositoryService;
        }

        /// <summary>
        /// Returns List of ExamResults
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //public async Task<IEnumerable<ExamSubjectViewModel>> Get()
        public async Task<ActionResult> Get()
        {
            var examResults = await _examRepository.GetExamResults();

            //if(examResults == null)
            //{
            //    _logger.LogInformation($"Exam Result list is empty");
            //    return new List<ExamResultsViewModel>();
            //}

            var result = Mapper.Map<List<ExamSubjectViewModel>>(examResults);
            
            return Ok(result);
        }
    }
}
