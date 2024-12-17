using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PlanOfStudy.Models
{
    public class POSDbContext : DbContext
    {
        public POSDbContext(DbContextOptions<POSDbContext> options)
            : base(options) { }
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<SavedPlan> SavedPlans => Set<SavedPlan>();
    }
}