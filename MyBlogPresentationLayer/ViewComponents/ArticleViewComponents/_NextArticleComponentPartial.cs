using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlogPresentationLayer.ViewComponents.ArticleViewComponents
{
    public class _NextArticleComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _NextArticleComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _articleService.TGetListAll();

            int currentArticleIndex = values.FindIndex(x => x.ArticleId == id);

            if (currentArticleIndex >= 0 && currentArticleIndex < values.Count - 1)
            {

                int nextArticleIndex = values[currentArticleIndex + 1].ArticleId;
                var value = _articleService.TGetArticlesWithCategoryByArticleId(nextArticleIndex);
                return View(value);
            }
            return View();
        }
    }
}
