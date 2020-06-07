using ExamResultsLister.API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ExamResultsLister.API.Services
{
    public class ExamRepositoryService : IExamRepositoryService
    {     
        /// <summary>
        /// Return list of ExamSubject objects from data file
        /// </summary>
        /// <returns></returns>
        public async Task<List<ExamSubject>> GetExamResults()
        {
            var file = await File.ReadAllTextAsync("Data.json");

            var result = JsonConvert.DeserializeObject<List<ExamSubject>>(file);

            return result;
        }        
    }
}
