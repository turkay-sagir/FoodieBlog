using Microsoft.AspNetCore.Mvc;

namespace MyBlogPresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
