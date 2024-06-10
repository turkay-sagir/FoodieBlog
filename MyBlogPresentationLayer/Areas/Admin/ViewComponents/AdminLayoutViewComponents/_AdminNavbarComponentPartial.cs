using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminNavbarComponentPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AdminNavbarComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.userInfo = user.Name + " " + user.Surname;
            ViewBag.userImage = user.ImageUrl;

            return View();
        }
    }
}
