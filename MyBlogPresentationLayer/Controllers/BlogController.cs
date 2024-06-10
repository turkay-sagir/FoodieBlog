using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlogPresentationLayer.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult BlogDetail(int id)
        {
            ViewBag.ArticleId = id;
            return View();
        }

    }
}
