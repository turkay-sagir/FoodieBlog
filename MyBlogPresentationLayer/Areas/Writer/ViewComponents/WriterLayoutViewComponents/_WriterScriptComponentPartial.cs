using Microsoft.AspNetCore.Mvc;

namespace MyBlogPresentationLayer.Areas.Writer.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
