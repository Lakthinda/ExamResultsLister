namespace ExamResultsLister.Models
{
    public class Results
    {
        public int Year { get; set; }
        public GradeType Grade { get; set; }
    }

    public enum GradeType { Pass, Fail}
}
