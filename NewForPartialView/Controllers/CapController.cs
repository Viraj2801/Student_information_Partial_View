using Microsoft.AspNetCore.Mvc;

namespace NewForPartialView.Controllers
{
    public class CapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection fc)
        {
            return View();
        }
    }
}
