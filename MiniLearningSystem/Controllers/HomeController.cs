using MiniLearningSystem.Services;
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
            var courses = _courseService.GetAll();

            return View();
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