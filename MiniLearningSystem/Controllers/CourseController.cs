using AutoMapper;
using MiniLearningSystem.Models.EntityModels;
using MiniLearningSystem.Models.ViewModels.Course;
using MiniLearningSystem.Services.Interfaces;
using System.Web.Mvc;

namespace MiniLearningSystem.Web.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public ActionResult Details(int id)
        {
            var course = Mapper.Map<Course,CourseDetailsVm>(_courseService.GetById(id));

            return View(course);
        }

        public ActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourse(CreateCourseVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!_courseService.Create(model))
            {
                ViewData["Error"] = "Something went wrong! Please try again.";
                return View(model);
            }

            TempData["CourseCreated"] = "Successfuly created course!";
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}