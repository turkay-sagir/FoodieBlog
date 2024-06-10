using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlogPresentationLayer.ViewComponents.UserViewComponents
{
    public class _AuthorDetailComponentPartial:ViewComponent
    {
        private readonly IAppUserService _userService;

        public _AuthorDetailComponentPartial(IAppUserService userService)
        {
            _userService = userService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _userService.TGetUserByArticle(id);
            return View(values);
        }
    }
}
