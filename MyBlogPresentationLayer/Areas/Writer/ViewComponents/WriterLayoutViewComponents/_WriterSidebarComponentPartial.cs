using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Admin.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterSidebarComponentPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;

        public _WriterSidebarComponentPartial(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _userManager = userManager;
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByWriter(user.Id);
            ViewBag.userInfo = user.Name + " " + user.Surname;
            ViewBag.articleCount = values.Count;
            ViewBag.userCity = user.City;
            ViewBag.userImage = user.ImageUrl;
            return View();
        }
    }
}
