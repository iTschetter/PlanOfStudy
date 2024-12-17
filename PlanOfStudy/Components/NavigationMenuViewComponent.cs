using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using PlanOfStudy.Models;

namespace PlanOfStudy.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IPOSRepository repository;
        public NavigationMenuViewComponent(IPOSRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Courses
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}