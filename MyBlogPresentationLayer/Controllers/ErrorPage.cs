using Microsoft.AspNetCore.Mvc;

namespace MyBlogPresentationLayer.Controllers
{
    public class ErrorPage : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
