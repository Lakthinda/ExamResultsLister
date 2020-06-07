using System.Collections.Generic;

namespace ExamResultsLister.API.Models
{
    public class ExamSubject
    {
        public string Subject { get; set; }
        public List<Results> Results { get; set; }
    }
}
