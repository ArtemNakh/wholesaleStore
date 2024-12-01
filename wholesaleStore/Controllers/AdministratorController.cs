using Microsoft.AspNetCore.Mvc;
using wholesaleStore.Core.Interfaces;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IAdministratorService _administratorService;

        public AdministratorController(IAdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        [HttpGet]
        [Route("LoginAdmin")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("LoginAdmin")]
        public async Task<IActionResult> Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError(string.Empty, "Login and Password are required.");
                return View();
            }

            Administrator administrator = (await _administratorService.GetAllAdministrators()).Where(a => a.Login == login && a.Password == password).FirstOrDefault();

            if (administrator == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid Login or Password.");
                return View();
            }

            HttpContext.Session.SetInt32("AdministratorId", administrator.Id);
            HttpContext.Session.SetInt32("EnterpriceId", administrator.Enterprice.Id);

            return RedirectToAction("Index", "Enterprice");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdministratorId");

            return RedirectToAction("Login", "Administrator");
        }
    }
}
