using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Notification")]
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

            return RedirectToAction("Index", "Notification", new { Area = "Writer" });
        }
    }
}
