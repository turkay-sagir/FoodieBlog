using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminSidebarComponentPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;

        public _AdminSidebarComponentPartial(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _userManager = userManager;
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByWriter(user.Id);
            ViewBag.articleCount = values.Count;
            return View(user);
        }
    }
}
