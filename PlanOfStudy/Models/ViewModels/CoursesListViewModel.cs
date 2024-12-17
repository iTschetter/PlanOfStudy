namespace PlanOfStudy.Models.ViewModels
{
    public class CoursesListViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
            = Enumerable.Empty<Course>();
        public PagingInfo PagingInfo { get; set; } = new();
        public string? CurrentCategory { get; set; }
    }
}