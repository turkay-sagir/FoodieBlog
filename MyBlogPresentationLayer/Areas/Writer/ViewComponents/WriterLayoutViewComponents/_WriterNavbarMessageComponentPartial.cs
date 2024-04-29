using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Writer.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterNavbarMessageComponentPartial:ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public _WriterNavbarMessageComponentPartial(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _messageService.TGetListOfReceivedMessage(user.Email);
            ViewBag.messageCount = values.Count();
            return View(values);
        }
    }
}
