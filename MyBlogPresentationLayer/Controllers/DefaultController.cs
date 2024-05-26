using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using System.Runtime.CompilerServices;

namespace MyBlogPresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IArticleService _articleService;

        public DefaultController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
