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

        public IViewComponentResult Invoke(int id) //BlogDetail içinde kullanılıyor
        {
            
            var values = _commentService.TGetCommentsWithUserByBlog(id).Where(x=>x.Status=="Onaylandı").ToList();
            return View(values);
        }
    }
}
