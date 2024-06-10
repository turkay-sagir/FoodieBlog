using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        [Route("AllCommentList")]
        public async Task<IActionResult> AllCommentList()
        {
            var values = _commentService.TGetAllCommentsOfAllBlogs();

            return View(values);
        }

        [Route("CommentList")]
        public async Task<IActionResult> CommentList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var values = _commentService.TGetCommentsOfBlogsByWriter(user.Id);

            return View(values);
        }

        [Route("CommentDetail/{id}")]
        public async Task<IActionResult> CommentDetail(int id)
        {
            var value = _commentService.TGetCommentWithUserAndBlog(id);
            return View(value);
        }

        public IActionResult StatusChangeComment(int id,string state)
        {
            var value = _commentService.TGetById(id);

            value.Status = state;

            _commentService.TUpdate(value);
            return RedirectToAction("CommentList", "Comment", new { area = "Admin" });
        }
    }
}
