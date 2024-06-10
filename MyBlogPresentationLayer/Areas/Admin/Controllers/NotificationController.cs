using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Notification")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _notificationService.TGetListAll();
            return View(values);
        }

        [Route("StatusChangeNotification/{id}")]
        public IActionResult StatusChangeNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            if (value.Status == true)
            {
                value.Status = false;
            }

            else
            {
                value.Status = true;
            }

            _notificationService.TUpdate(value);

            return RedirectToAction("Index", "Notification", new { Area = "Admin" });
        }
    }
}
