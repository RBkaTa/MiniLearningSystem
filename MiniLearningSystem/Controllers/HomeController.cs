using MiniLearningSystem.Models.ViewModels.Course;
using MiniLearningSystem.Services;
using System.Linq;
using System.Web.Mvc;

namespace MiniLearningSystem.Controllers
{
    public class HomeController : Controller
    {
        private CourseService _courseService;

        public HomeController()
        {
            _courseService = new CourseService();
        }

        public ActionResult Index()
        {   
            var courses = _courseService.GetAll().Select(c => new CourseIndexVm()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                StartDate = c.StartDate,
                EndDate = c.EndDate
            }).ToList();

            return View(courses);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}