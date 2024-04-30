using Microsoft.AspNetCore.Mvc;

namespace MyBlogPresentationLayer.ViewComponents.CommentViewComponents
{
    public class _CreateCommentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
