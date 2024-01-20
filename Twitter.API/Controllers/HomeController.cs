using Microsoft.AspNetCore.Mvc;

namespace Twitter.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
