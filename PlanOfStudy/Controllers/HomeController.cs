using Microsoft.AspNetCore.Mvc;
using PlanOfStudy.Models;
using PlanOfStudy.Models.ViewModels;
namespace PlanOfStudy.Controllers
{
    public class HomeController : Controller
    {
        private IPOSRepository repository;
        public int PageSize = 4;
        public HomeController(IPOSRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(string? category, int coursePage = 1)
           => View(new CoursesListViewModel
           {
               Courses = repository.Courses
                   .Where(p => category == null || p.Category == category)
                   .OrderBy(p => p.CourseNumber)
                   .Skip((coursePage - 1) * PageSize)
                   .Take(PageSize),
               PagingInfo = new PagingInfo
               {
                   CurrentPage = coursePage,
                   ItemsPerPage = PageSize,
                   TotalItems = category == null
                        ? repository.Courses.Count()
                        : repository.Courses.Where(e =>
                            e.Category == category).Count()
               },
               CurrentCategory = category
           });
    }
}