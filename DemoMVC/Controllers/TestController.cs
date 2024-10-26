namespace Test.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
[HttpPost]
        public IActionResult Index(string FullName, string Msv)
        {
            ViewBag.message= "helo" + FullName + "-" +Msv ;
            return View();
        }
    }
}