using Microsoft.AspNetCore.Mvc;

namespace MyBlogPresentationLayer.ViewComponents.ContactViewComponents
{
    public class _ContactComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
