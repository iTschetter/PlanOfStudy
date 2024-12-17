using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace PlanOfStudy.Models
{
    public class SavedPlan
    {
        [BindNever]
        public int SavedPlanID { get; set; }
        [BindNever]
        public ICollection<PlanLine> Lines { get; set; } = new List<PlanLine>();
        [Required(ErrorMessage = "Please enter a name")]
        public string? Name { get; set; }
        [BindNever]
        public bool Active { get; set; }
    }
}