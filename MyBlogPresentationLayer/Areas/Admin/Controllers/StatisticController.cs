using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlogPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Statistic")]
    public class StatisticController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;
        private readonly ICommentService _commentService;
        private readonly INotificationService _notificationService;
        private readonly ICategoryService _categoryService;

        public StatisticController(IArticleService articleService, UserManager<AppUser> userManager, IMessageService messageService, ICommentService commentService, INotificationService notificationService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _messageService = messageService;
            _commentService = commentService;
            _notificationService = notificationService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var article = _articleService.TGetArticlesByWriter(user.Id);
            var receivedMessage = _messageService.TGetListOfReceivedMessage(user.Email);
            var comment = _commentService.TGetCommentsOfBlogsByWriter(user.Id);
            var notification = _notificationService.TGetListAll();
            var category = _categoryService.TGetListAll();
            


            ViewBag.blogCount = article.Count();
            ViewBag.lastBlog = article.OrderByDescending(x => x.ArticleId).Select(x => x.Title).FirstOrDefault();
            ViewBag.firstBlog = article.Select(x=>x.Title).FirstOrDefault();
            ViewBag.mostCommentedArticle = article.Where(x => x.ArticleId == _articleService.TMostCommentedArticle(user.Id)).Select(x => x.Title).FirstOrDefault();
            ViewBag.receivedMessageCount = receivedMessage.Count();
            ViewBag.unreadReceivedMessageCount = receivedMessage.Where(x => x.Status == false).Count();
            ViewBag.commentsCount = comment.Count();
            ViewBag.commentsForApproveCount = comment.Where(x => x.Status == "Bekliyor").Count();
            ViewBag.notificationCount = notification.Count();
            ViewBag.categoryCount = category.Count();
            ViewBag.firstCategory = category.Select(x=>x.CategoryName).FirstOrDefault();
            ViewBag.lastCategory = category.OrderByDescending(x=>x.CategoryId).Select(x=>x.CategoryName).FirstOrDefault();


            return View();
        }
    }
}
