using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using Newtonsoft.Json;

namespace MyBlogPresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        [HttpPost]
        public JsonResult CreateComment(Comment p)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);

            if (user!=null)
            {
                p.CreatedDate= DateTime.Now;
                p.Status = true;

                _commentService.TInsert(p);
            }

            return Json(p);
        }
    }
}
