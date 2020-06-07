using ExamResultsLister.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamResultsLister.Services
{    
    public interface IExamAPIService
    {
        Task<List<ExamSubject>> GetExamResults();
    }
}
