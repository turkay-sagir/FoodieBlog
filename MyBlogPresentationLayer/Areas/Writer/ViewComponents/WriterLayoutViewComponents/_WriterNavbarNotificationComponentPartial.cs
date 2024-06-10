using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Admin.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterNavbarNotificationComponentPartial:ViewComponent
    {
        private readonly INotificationService _notificationService;

        public _WriterNavbarNotificationComponentPartial(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _notificationService.TGetListAll().Where(x => x.Status == true).TakeLast(3).ToList();
            ViewBag.notificationCount = values.Count();
            return View(values);
        }
    }
}
