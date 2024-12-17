namespace PlanOfStudy.Models
{
    public interface ISavedPlanRepository
    {
        IQueryable<SavedPlan> SavedPlans { get; }
        void SaveSavedPlan(SavedPlan savedplan);
    }
}