using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlogPresentationLayer.ViewComponents.ArticleTagViewComponents
{
    public class _ArticleTagListComponentPartial:ViewComponent
    {
        private readonly IArticleTagService _articleTagService;

        public _ArticleTagListComponentPartial(IArticleTagService articleTagService)
        {
            _articleTagService = articleTagService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var value = _articleTagService.TGetTagListByArticle(id);
            return View(value);
        }
    }
}
