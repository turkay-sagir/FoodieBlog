using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using System.Runtime.CompilerServices;

namespace MyBlogPresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialCreateComment()
        {
            return PartialView();
        }

    }
}
