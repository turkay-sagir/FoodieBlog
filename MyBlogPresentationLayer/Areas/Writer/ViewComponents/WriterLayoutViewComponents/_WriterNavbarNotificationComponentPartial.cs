using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Writer.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterNavbarNotificationComponentPartial:ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
