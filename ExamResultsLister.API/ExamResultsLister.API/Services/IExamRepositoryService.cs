using ExamResultsLister.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamResultsLister.API.Services
{
    public interface IExamRepositoryService
    {
        Task<List<ExamSubject>> GetExamResults();
    }
}
