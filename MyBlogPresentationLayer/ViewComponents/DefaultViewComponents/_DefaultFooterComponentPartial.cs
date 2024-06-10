using Microsoft.AspNetCore.Mvc;

namespace MyBlogPresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
