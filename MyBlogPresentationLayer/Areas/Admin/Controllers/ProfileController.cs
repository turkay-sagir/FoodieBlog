using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;
using MyBlogPresentationLayer.Areas.Admin.Models;

namespace MyBlogPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Profile")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("EditProfile")]
        public async Task<IActionResult> EditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AdminEditViewModel model = new AdminEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.Email = values.Email;
            model.PhoneNumber = values.PhoneNumber;
            model.ImageUrl = values.ImageUrl;
            model.City = values.City;
            model.Username = values.UserName;

            return View(model);
        }


        [HttpPost]
        [Route("EditProfile")]
        public async Task<IActionResult> EditProfile(AdminEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if(p.Image!=null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.ImageUrl = imageName;

            }

            user.Name = p.Name;
            user.Surname = p.Surname;
            user.Email = p.Email;
            user.PhoneNumber = p.PhoneNumber;
            user.City = p.City;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);

            var result = await _userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                return RedirectToAction("MyBlogList", "Blog", new { Area = "Admin" });
            }

            return View();
        }
    }
}
