using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminNavbarNotificationComponentPartial:ViewComponent
    {
        private readonly INotificationService _notificationService;

        public _AdminNavbarNotificationComponentPartial(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _notificationService.TGetListAll().Where(x => x.Status == false).TakeLast(3).ToList();
            ViewBag.notificationCount = values.Count();
            return View(values);
        }
    }
}
