using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Blog")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IArticleTagService _articleTagService;

        public BlogController(UserManager<AppUser> userManager, IArticleService articleService, ICategoryService categoryService, ITagService tagService, IArticleTagService articleTagService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
            _tagService = tagService;
            _articleTagService = articleTagService;
        }

        [Route("MyBlogList")]
        public async Task<IActionResult> MyBlogList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesWithCategoryByWriter(user.Id);

            return View(values);
        }

        [Route("DeleteBlog/{id}")]
        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("MyBlogList", "Blog", new {area="Writer"});
        }

        [HttpGet]
        [Route("UpdateBlog/{id}")]
        public IActionResult UpdateBlog(int id)
        {
            List<SelectListItem> values = (from x in _categoryService.TGetListAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }
                                           ).ToList();
            ViewBag.v = values;

            var values2 = _articleService.TGetById(id);
            return View(values2);
        }

        [HttpPost]
        [Route("UpdateBlog/{id}")]
        public IActionResult UpdateBlog(Article article)
        {
            _articleService.TUpdate(article);
            return RedirectToAction("MyBlogList");
        }

        [HttpGet]
        [Route("CreateBlog")]
        public IActionResult CreateBlog()
        {
            List<SelectListItem> values = (from x in _categoryService.TGetListAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }
                                           ).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        [Route("CreateBlog")]
        public async Task<IActionResult> CreateBlog(Article article)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            article.CreatedDate = DateTime.Now;
            article.AppUserId = user.Id;

            _articleService.TInsert(article);
            return RedirectToAction("MyBlogList","Blog", new {area="Writer"});
        }


        [HttpGet]
        [Route("AddTag/{id}")]
        public IActionResult AddTag(int id)
        {
            var allTags = _tagService.TGetListAll();

            var currentTagsIds = _articleTagService.TGetTagListByArticle(id).Select(x => x.TagId).ToList();

            List<SelectListItem> tagList = (from i in allTags
                                         select new SelectListItem
                                         {
                                             Text = i.TagTitle,
                                             Value = i.TagId.ToString(),
                                             Selected = currentTagsIds.Contains(i.TagId)
                                         }).ToList();

            ViewBag.tagList = tagList;
            ViewBag.articleId = id;
            return View();
        }

        [HttpPost]
        [Route("AddTag/{articleId}")]
        public IActionResult AddTag(List<int> SelectedTagIds, int articleId)
        {
            var article = _articleService.TGetById(articleId);
            var currentTagsIds = _articleTagService.TGetTagListByArticle(articleId).Select(x=>x.TagId).ToList(); //blogun mevcut etiketlerinin Id listesi

            foreach (var item in currentTagsIds) //seçilen etiketlerde, mevcut etiket yer almıyorsa mevcut etiketi kaldırma işlemi
            {
                if(!SelectedTagIds.Contains(item))
                {
                    var value = _articleTagService.TGetArticleTagByTagIdAndArticleId(item, articleId); //mevcut etiketin ArticleTagId değerini bulma işlemi
                    _articleTagService.TDelete(value.ArticleTagId);
                }
            }

            foreach (var item in SelectedTagIds) //seçilen etiketleri ekleme işlemi
            {
                if(article.ArticleTags==null)
                {
                    article.ArticleTags = new List<ArticleTag>();
                }

                article.ArticleTags.Add(

                    new ArticleTag { 
                    
                        ArticleId = articleId,
                        TagId = item
                    
                    });
            }

            _articleService.TUpdate(article);
            return RedirectToAction("MyBlogList","Blog",new {area="Writer"});
        }
    }
}
