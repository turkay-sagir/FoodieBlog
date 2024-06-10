using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlogPresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _CategoryComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoryComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetCategoriesWithArticleCount();
            return View(values);
        }
    }
}
