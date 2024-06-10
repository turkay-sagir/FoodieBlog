using Microsoft.AspNetCore.Mvc;

namespace MyBlogPresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _FeaturePostComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View(); 
        }

    }
}
