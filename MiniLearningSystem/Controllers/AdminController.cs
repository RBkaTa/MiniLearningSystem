using MiniLearningSystem.Models.ViewModels.Admin;
using MiniLearningSystem.Services;
using System.Linq;
using System.Web.Mvc;

namespace MiniLearningSystem.Web.Controllers
{
    public class AdminController : Controller
    {
        private const string SetRoleSuccessMessage = "You successfuly set {0} role to {1}!";
        private const string SetRoleErrorMessage = "Something went wrong! Please try again.";

        private AdminService _adminService;
        private AccountService _accountService;

        public AdminController()
        {
            _adminService = new AdminService();
            _accountService = new AccountService();
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
    }
}