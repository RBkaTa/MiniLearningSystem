using AutoMapper;
using MiniLearningSystem.Models.EntityModels;
using MiniLearningSystem.Models.ViewModels.Course;
using MiniLearningSystem.Services;
using System.Web.Mvc;

namespace MiniLearningSystem.Web.Controllers
{
    public class CourseController : Controller
    {
        private CourseService _courseService;

        public CourseController()
        {
            _courseService = new CourseService();
        }

        public ActionResult Details(int id)
        {
            var course = Mapper.Map<Course,CourseDetailsVm>(_courseService.GetById(id));

            return View(course);
        }
    }
}