using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class JavaScriptHoc : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
