using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlogPresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _BlogListComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public _BlogListComponentPartial(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetArticlesWithCategoryAndUser();
            return View(values);
        }
    }
}
