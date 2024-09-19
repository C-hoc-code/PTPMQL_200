namespace DemoMvc.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

    }
}