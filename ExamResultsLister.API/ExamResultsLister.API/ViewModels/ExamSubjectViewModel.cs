using System.Collections.Generic;

namespace ExamResultsLister.API.ViewModels
{
    public class ExamSubjectViewModel
    {
        public string Subject { get; set; }
        public List<ResultsViewModel> Results { get; set; }
    }
}
