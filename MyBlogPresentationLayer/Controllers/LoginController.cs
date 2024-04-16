using Microsoft.AspNetCore.Mvc;

namespace MyBlogPresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
