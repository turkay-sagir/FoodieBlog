using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlogPresentationLayer.ViewComponents.ArticleViewComponents
{
    public class _ArticleDetailComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleDetailComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var value = _articleService.TGetArticleWithCategoryAndUser(id);
            return View(value);
        }
    }
}
