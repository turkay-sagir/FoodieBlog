using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlogPresentationLayer.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        public IActionResult BlogDetail(int id)
        {
            ViewBag.ArticleId = id;
            return View();
        }

    }
}
