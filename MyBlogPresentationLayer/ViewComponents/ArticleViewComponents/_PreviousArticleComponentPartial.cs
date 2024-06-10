using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.ViewComponents.ArticleViewComponents
{
    public class _PreviousArticleComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _PreviousArticleComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _articleService.TGetListAll();

            int currentArticleIndex = values.FindIndex(x => x.ArticleId == id);

            if(currentArticleIndex>0)
            {

                int previousArticleIndex = values[currentArticleIndex - 1].ArticleId;
                var value = _articleService.TGetArticlesWithCategoryByArticleId(previousArticleIndex);
                return View(value);
            }

            return View(null);
        }
    }
}
