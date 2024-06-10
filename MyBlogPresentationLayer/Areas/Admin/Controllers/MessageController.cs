using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Message")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        [Route("Inbox")]
        public async Task<IActionResult> Inbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _messageService.TGetListOfReceivedMessage(user.Email);
            return View(values);
        }

        [Route("SentItems")]
        public async Task<IActionResult> SentItems()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _messageService.TGetListOfSentMessage(user.Email);
            return View(values);
        }

        [HttpGet]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(Message p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            p.Sender = user.Email;
            p.SenderName = user.Name + " " + user.Surname;
            p.CreatedDate = DateTime.Now;
            p.Status = false;

            BlogContext context = new BlogContext();
            p.ReceiverName = context.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();

            _messageService.TInsert(p);
            return RedirectToAction("SentItems", "Message", new { area = "Admin" });
        }


        [Route("StatusChangeReceivedMessage/{id}")]
        public IActionResult StatusChangeReceivedMessage(int id)
        {
            var value = _messageService.TGetById(id);
            if(value.Status==true)
            {
                value.Status= false;
            }
            else
            {
                value.Status= true;
            }

            _messageService.TUpdate(value);

            return RedirectToAction("Inbox", "Message", new { area = "Admin" });
        }

        [Route("StatusChangeSentMessage/{id}")]
        public IActionResult StatusChangeSentMessage(int id)
        {
            var value = _messageService.TGetById(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }

            _messageService.TUpdate(value);

            return RedirectToAction("SentItems", "Message", new { area = "Admin" });
        }


    }
}
