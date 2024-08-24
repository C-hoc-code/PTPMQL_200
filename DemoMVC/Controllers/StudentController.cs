using Microsoft.AspNetCore.Mvc;
namespace DemoMVC.Controllers;

public class StudentController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

}