namespace PlanOfStudy.Models
{
    public interface IPOSRepository
    {
        IQueryable<Course> Courses { get; }
        void SaveCourse(Course p);
        void CreateCourse(Course p);
        void DeleteCourse(Course p);
    }
}