﻿using Microsoft.AspNetCore.Mvc;

namespace MyBlogPresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _NavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
