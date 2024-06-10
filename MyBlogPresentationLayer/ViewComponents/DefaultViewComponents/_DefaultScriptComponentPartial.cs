using Microsoft.AspNetCore.Mvc;

namespace MyBlogPresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
