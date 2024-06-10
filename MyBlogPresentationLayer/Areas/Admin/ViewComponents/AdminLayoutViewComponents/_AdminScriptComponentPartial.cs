using Microsoft.AspNetCore.Mvc;

namespace MyBlogPresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
