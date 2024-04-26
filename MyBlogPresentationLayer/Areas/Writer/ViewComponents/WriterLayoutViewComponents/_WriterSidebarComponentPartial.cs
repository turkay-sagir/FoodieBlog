using Microsoft.AspNetCore.Mvc;

namespace MyBlogPresentationLayer.Areas.Writer.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
