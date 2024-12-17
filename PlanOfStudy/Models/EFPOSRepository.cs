namespace PlanOfStudy.Models
{
    public class EFPOSRepository : IPOSRepository
    {
        private POSDbContext context;
        public EFPOSRepository(POSDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Course> Courses => context.Courses;
        public void CreateCourse(Course p)
        {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeleteCourse(Course p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
        public void SaveCourse(Course p)
        {
            context.SaveChanges();
        }
    }
}