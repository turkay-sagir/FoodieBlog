using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using System.Globalization;
using System.Xml.Linq;

namespace MyBlogPresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Dashboard")]
    public class DashboardController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IMessageService _messageService;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IArticleService articleService, UserManager<AppUser> userManager, IMessageService messageService, ICommentService commentService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _messageService = messageService;
            _commentService = commentService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            //weather forecast information
            string api = "38d6af1b55a940c807e9d7a4fd61d529";
            string connection = "https://api.openweathermap.org/data/2.5/weather?lat=41.25&lon=36.333&units=metric&mode=xml&lang=tr&appid=" + api;
            XDocument xDocument = XDocument.Load(connection);
            ViewBag.temperature = xDocument.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.feelsTemperature = xDocument.Descendants("feels_like").ElementAt(0).Attribute("value").Value;

            if ((xDocument.Descendants("precipitation").ElementAt(0).Attribute("mode").Value) != "no")
            {
                ViewBag.precipitation = "%"+(xDocument.Descendants("precipitation").ElementAt(0).Attribute("value").Value).Substring(2, 2);
            }

            else
            {
                ViewBag.precipitation = "Yağış Yok";
            }

            ViewBag.humidity = xDocument.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            ViewBag.windSpeed = xDocument.Descendants("wind").Elements("speed").FirstOrDefault()?.Attribute("value").Value;
            ViewBag.windDirection = xDocument.Descendants("wind").Elements("direction").FirstOrDefault()?.Attribute("value").Value;
            ViewBag.clouds = xDocument.Descendants("clouds").ElementAt(0).Attribute("value").Value;
            ViewBag.weather = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(xDocument.Descendants("weather").ElementAt(0).Attribute("value").Value);
            ViewBag.cloudsName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(xDocument.Descendants("clouds").ElementAt(0).Attribute("name").Value);
            ViewBag.sunRise = (xDocument.Descendants("sun").ElementAt(0).Attribute("rise").Value).Substring(11, 5);
            ViewBag.sunSet = (xDocument.Descendants("sun").ElementAt(0).Attribute("set").Value).Substring(11, 5);
            ViewBag.cityName = xDocument.Descendants("city").ElementAt(0).Attribute("name").Value;
            ViewBag.date = DateTime.Now.ToString("D");
            ViewBag.time = DateTime.Now.ToString("t");


            //Veriler

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var article = _articleService.TGetArticlesByWriter(user.Id);
            var receivedMessage = _messageService.TGetListOfReceivedMessage(user.Email);
            var sentMessage = _messageService.TGetListOfSentMessage(user.Email);
            var comment = _commentService.TGetCommentsOfBlogsByWriter(user.Id);
            
            ViewBag.blogCount = article.Count();
            ViewBag.receivedMessageCount = receivedMessage.Count();
            ViewBag.sentMessageCount = sentMessage.Count();
            ViewBag.commentCount = comment.Count();
            return View();
        }
    }
}
