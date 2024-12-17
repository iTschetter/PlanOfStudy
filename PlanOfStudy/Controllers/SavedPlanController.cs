using Microsoft.AspNetCore.Mvc;
using PlanOfStudy.Models;
namespace PlanOfStudy.Controllers
{
    public class SavedPlanController : Controller
    {
        private ISavedPlanRepository repository;
        private Plan plan;
        public SavedPlanController(ISavedPlanRepository repoService, Plan planService)
        {
            repository = repoService;
            plan = planService;
        }
        public ViewResult SavePlan() => View(new SavedPlan());
        [HttpPost]
        public IActionResult SavePlan(SavedPlan savedplan)
        {
            if (plan.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your plan is empty!");
            }
            if (ModelState.IsValid)
            {
                savedplan.Lines = plan.Lines.ToArray();
                repository.SaveSavedPlan (savedplan);
                plan.Clear();
                return RedirectToPage("/Completed", new { SavedPlanName = savedplan.Name });
            }
            else
            {
                return View();
            }
        }
    }
}