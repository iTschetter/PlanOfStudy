using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanOfStudy.Infrastructure;
using PlanOfStudy.Models;

namespace PlanOfStudy.Pages
{
    public class PlanModel : PageModel
    {
        private IPOSRepository repository;
        public PlanModel(IPOSRepository repo, Plan planService)
        {
            repository = repo;
            Plan = planService;
        }
        public Plan Plan { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Plan = HttpContext.Session.GetJson<Plan>("plan") ?? new Plan();
        }
        public IActionResult OnPost(long courseId, string returnUrl)
        {
            Course? course = repository.Courses
                .FirstOrDefault(p => p.CourseID == courseId);
            if (course != null)
            {
                Plan.AddItem(course, 1);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long courseId, string returnUrl)
        {
            Plan.RemoveLine(Plan.Lines.First(cl =>
                cl.Course.CourseID == courseId).Course);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
