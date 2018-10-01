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
            CourseDetailsVm course;

            if (!this.User.Identity.IsAuthenticated)
            {
                course = Mapper.Map<Course,CourseDetailsVm>(_courseService.GetById(id));
            }
            else
            {
                //course = _courseService.GetDetailedById(id);
                course = Mapper.Map<Course, CourseDetailsVm>(_courseService.GetById(id));
                course.IsApplyed = _courseService.IsCourseApplied(id);
            }

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

        public ActionResult AddStudent(int courseId)
        {
            var added = _courseService.AddStudent(courseId);

            if (!added.success)
            {
                ViewData["Error"] = "Something went wrong! Please try again.";
                return RedirectToAction("Index", "Home");
            }

            TempData["Success"] = $"You successfuly apply for {added.courseName}";

            return RedirectToAction("Details", "Course", new { id = courseId });
        }
        
        public ActionResult RemoveStudent(int courseId)
        {
            var removed = _courseService.RemoveStudent(courseId);

            if (!removed.success)
            {
                ViewData["Error"] = "Something went wrong! Please try again.";
                return RedirectToAction("Index", "Home");
            }

            TempData["Error"] = $"You successfuly removed {removed.courseName} from your courses!";

            return RedirectToAction("Details", new { id = courseId });
        }
    }
}