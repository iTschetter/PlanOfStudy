using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PlanOfStudy.Models
{
    public class Course
    {
        public long? CourseID { get; set; }
        [Required(ErrorMessage = "Please enter a course name")]
        public string CourseNumber { get; set; } = String.Empty;
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; } = String.Empty;
        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8, 2)")]
        public int Credits { get; set; }
        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; } = String.Empty;
    }
}