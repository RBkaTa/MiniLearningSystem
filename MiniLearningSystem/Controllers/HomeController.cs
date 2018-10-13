using AutoMapper;
using MiniLearningSystem.Models.EntityModels;
using MiniLearningSystem.Models.ViewModels;
using MiniLearningSystem.Models.ViewModels.Chat;
using MiniLearningSystem.Models.ViewModels.Course;
using MiniLearningSystem.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MiniLearningSystem.Controllers
{
    public class HomeController : Controller
    {
        private ICourseService _courseService;
        private IAccountService _accountService;

        public HomeController(ICourseService courseService, IAccountService accountService)
        {
            _courseService = courseService;
            _accountService = accountService;
        }

        public ActionResult Index()
        {
            var users = new UserListVm();
            users.Users = Mapper.Map<ICollection<ApplicationUser>, IList<UserListDetailsVm>>(_accountService.GetAll());

            HttpContext.Session["user-list"] = users;

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

        public ActionResult Chat(string id)
        {
            var sender = _accountService.GetById(id);

            var model = new ChatVm()
            {
                Id = sender.Id,
                SenderName = sender.UserName,
            };

            return PartialView(model);
        }
    }
}