using MiniLearningSystem.Models.ViewModels.Admin;
using MiniLearningSystem.Services;
using MiniLearningSystem.Services.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace MiniLearningSystem.Web.Controllers
{
    public class AdminController : Controller
    {
        private const string SetRoleSuccessMessage = "You successfuly set {0} role to {1}!";
        private const string SetRoleErrorMessage = "Something went wrong! Please try again.";

        private IAdminService _adminService;
        private IAccountService _accountService;
        private ICourseService _courseService;

        public AdminController(IAdminService adminService, IAccountService accountService, ICourseService courseService)
        {
            _adminService = adminService;
            _accountService = accountService;
            _courseService = courseService;
        }

        public ActionResult SetRole()
        {
            ViewBag.Users = _accountService.GetAll().Select(u => u.UserName);

            return View();
        }

        [HttpPost]
        public ActionResult SetRole(SetRoleVm model)
        {
            ViewBag.Users = _accountService.GetAll().Select(u => u.UserName);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = _adminService.SetRole(model);

            if (!success.success)
            {
                ViewData["Error"] = SetRoleErrorMessage;
                return View();
            }

            ViewData["Success"] = string.Format(SetRoleSuccessMessage, model.Role.ToString(), success.username);
            return View();
        }

        public ActionResult SetTrainer()
        {
            ViewBag.Courses = _courseService.GetAll();
            ViewBag.Trainers = _accountService.GetTrainers();

            return View();
        }

        [HttpPost]
        public ActionResult SetTrainer(SetTrainerVm model)
        {
            ViewBag.Courses = _courseService.GetAll();
            ViewBag.Trainers = _accountService.GetTrainers();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var assigned = _adminService.SetTrainer(model);

            if (!assigned.success)
            {
                ViewData["Error"] = "Something went wrong! Please try again.";
                return View();
            }

            ViewData["Success"] = $"You successfuly assigned {assigned.trainer} as trainer for {assigned.course} course";
            return View();
        }
    }
}