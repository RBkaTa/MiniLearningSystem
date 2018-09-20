using AutoMapper;
using MiniLearningSystem.Models.EntityModels;
using MiniLearningSystem.Models.ViewModels.Course;
using MiniLearningSystem.Services;
using System.Collections.Generic;
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
            IList<CourseIndexVm> courses = null;

            if (this.User.Identity.IsAuthenticated)
            {
                courses = _courseService.SetApplyedCourses();
            }
            else
            {
                courses = Mapper.Map<ICollection<Course>, IList<CourseIndexVm>>(_courseService.GetAll());

            }

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