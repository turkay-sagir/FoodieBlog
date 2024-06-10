using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using System.Globalization;
using System.Xml.Linq;

namespace MyBlogPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Dashboard")]
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

            var temperatureElement = xDocument.Descendants("temperature").FirstOrDefault();
            var feelsLikeElement = xDocument.Descendants("feels_like").FirstOrDefault();
            var precipitationElement = xDocument.Descendants("precipitation").FirstOrDefault();
            var humidityElement = xDocument.Descendants("humidity").FirstOrDefault();
            var windSpeedElement = xDocument.Descendants("wind").Elements("speed").FirstOrDefault();
            var windDirectionElement = xDocument.Descendants("wind").Elements("direction").FirstOrDefault();
            var cloudsElement = xDocument.Descendants("clouds").FirstOrDefault();
            var weatherElement = xDocument.Descendants("weather").FirstOrDefault();
            var sunElement = xDocument.Descendants("sun").FirstOrDefault();
            var cityElement = xDocument.Descendants("city").FirstOrDefault();

            if (temperatureElement != null)
            {
                ViewBag.temperature = temperatureElement.Attribute("value")?.Value;
            }

            if (feelsLikeElement != null)
            {
                ViewBag.feelsTemperature = feelsLikeElement.Attribute("value")?.Value;
            }

            if (precipitationElement != null && precipitationElement.Attribute("mode")?.Value != "no")
            {
                ViewBag.precipitation = "%" + precipitationElement.Attribute("value")?.Value.Substring(2, 2);
            }
            else
            {
                ViewBag.precipitation = "Yağış Yok";
            }

            if (humidityElement != null)
            {
                ViewBag.humidity = humidityElement.Attribute("value")?.Value;
            }

            if (windSpeedElement != null)
            {
                ViewBag.windSpeed = windSpeedElement.Attribute("value")?.Value;
            }

            if (windDirectionElement != null)
            {
                ViewBag.windDirection = windDirectionElement.Attribute("value")?.Value;
            }

            if (cloudsElement != null)
            {
                ViewBag.clouds = cloudsElement.Attribute("value")?.Value;
            }

            if (weatherElement != null)
            {
                ViewBag.weather = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(weatherElement.Attribute("value")?.Value);
            }

            if (cloudsElement != null)
            {
                ViewBag.cloudsName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cloudsElement.Attribute("name")?.Value);
            }

            if (sunElement != null)
            {
                ViewBag.sunRise = sunElement.Attribute("rise")?.Value.Substring(11, 5);
                ViewBag.sunSet = sunElement.Attribute("set")?.Value.Substring(11, 5);
            }

            if (cityElement != null)
            {
                ViewBag.cityName = cityElement.Attribute("name")?.Value;
            }

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
