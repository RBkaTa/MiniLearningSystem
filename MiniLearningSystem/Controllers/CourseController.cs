using AutoMapper;
using MiniLearningSystem.Models.EntityModels;
using MiniLearningSystem.Models.ViewModels.Course;
using MiniLearningSystem.Services;
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
    }
}