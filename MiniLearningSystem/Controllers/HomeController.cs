using AutoMapper;
using MiniLearningSystem.Models.EntityModels;
using MiniLearningSystem.Models.ViewModels.Course;
using MiniLearningSystem.Services;
using MiniLearningSystem.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MiniLearningSystem.Controllers
{
    public class HomeController : Controller
    {
        private ICourseService _courseService;

        public HomeController(ICourseService courseService)
        {
            _courseService = courseService;
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

            _courseService.SetIcons(courses);

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