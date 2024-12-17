using Microsoft.EntityFrameworkCore;
namespace PlanOfStudy.Models
{
    public class EFSavedPlanRepository : ISavedPlanRepository
    {
        private POSDbContext context;
        public EFSavedPlanRepository(POSDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<SavedPlan> SavedPlans => context.SavedPlans
                            .Include(o => o.Lines)
                            .ThenInclude(l => l.Course);
        public void SaveSavedPlan(SavedPlan savedplan)
        {
            context.AttachRange(savedplan.Lines.Select(l => l.Course));
            if (savedplan.SavedPlanID == 0)
            {
                context.SavedPlans.Add(savedplan);
            }
            context.SaveChanges();
        }
    }
}