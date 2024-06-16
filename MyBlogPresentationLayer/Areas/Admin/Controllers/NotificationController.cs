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

        [Route("NotificationList")]
        public IActionResult NotificationList()
        {
            var values = _notificationService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        [Route("CreateNotification")]
        public IActionResult CreateNotification()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateNotification")]
        public IActionResult CreateNotification(Notification p)
        {
            p.CreatedDate = DateTime.Now;
            p.Status = true;

            _notificationService.TInsert(p);
            return RedirectToAction("NotificationList", "Notification", new { area = "Admin" });

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

            return RedirectToAction("NotificationList", "Notification", new { area = "Admin" });
        }
    }
}
