using ExamResultsLister.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamResultsLister.API.Services
{
    public class ExamRepositoryService : IExamRepositoryService
    {     
        public async Task<List<ExamSubject>> GetExamResults()
        {
            var file = await File.ReadAllTextAsync("Data.json");

            var result = JsonConvert.DeserializeObject<List<ExamSubject>>(file);

            return result;
        }        
    }
}
