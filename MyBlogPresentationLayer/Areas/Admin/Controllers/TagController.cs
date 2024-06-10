using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Tag")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [Route("TagList")]
        public IActionResult TagList()
        {
            var values = _tagService.TGetListAll();
            return View(values);
        }

        [Route("DeleteTag/{id}")]
        public IActionResult DeleteTag(int id)
        {
            _tagService.TDelete(id);
            return RedirectToAction("TagList", "Tag", new { area = "Admin" });
        }

        [HttpGet]
        [Route("CreateTag")]
        public IActionResult CreateTag()
        {
            return View();

        }

        [HttpPost]
        [Route("CreateTag")]
        public IActionResult CreateTag(Tag p)
        {
            _tagService.TInsert(p);
            return RedirectToAction("TagList", "Tag", new { area = "Admin" });
        }


        [HttpGet]
        [Route("UpdateTag/{id}")]
        public IActionResult UpdateTag(int id)
        {
            var value = _tagService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        [Route("UpdateTag/{id}")]
        public IActionResult UpdateTag(Tag p)
        {
            _tagService.TUpdate(p);
            return RedirectToAction("TagList", "Tag", new { area = "Admin" });
        }





    }
}
