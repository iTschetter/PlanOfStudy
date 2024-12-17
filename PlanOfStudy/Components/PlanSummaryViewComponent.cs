using Microsoft.AspNetCore.Mvc;
using PlanOfStudy.Models;
namespace PlanOfStudy.Components
{
    public class PlanSummaryViewComponent : ViewComponent
    {
        private Plan plan;
        public PlanSummaryViewComponent(Plan planService)
        {
            plan = planService;
        }
        public IViewComponentResult Invoke()
        {
            return View(plan);
        }
    }
}