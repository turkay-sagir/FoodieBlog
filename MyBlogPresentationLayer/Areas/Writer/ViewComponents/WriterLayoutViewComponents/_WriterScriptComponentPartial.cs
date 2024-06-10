using Microsoft.AspNetCore.Mvc;

namespace MyBlogPresentationLayer.Areas.Admin.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
