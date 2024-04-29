using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlogPresentationLayer.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentListByBlogComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            id = 2;
            var values = _commentService.TGetCommentsByBlog(id); //BlogDetail içinde kullanılıyor
            return View(values);
        }
    }
}
