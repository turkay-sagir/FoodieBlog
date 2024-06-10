using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;
using MyBlogPresentationLayer.Areas.Admin.Models;

namespace MyBlogPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    [Route("Admin/Role")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Route("RoleList")]
        public IActionResult RoleList()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        
        [HttpGet]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole()
        {
            return View();
        }

        
        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            AppRole appRole = new AppRole()
            {
                Name = createRoleViewModel.RoleName
            };

            var result = await _roleManager.CreateAsync(appRole);

            if(result.Succeeded)
            {
                return RedirectToAction("RoleList","Role",new {area="Admin"});
            }

            return View();
        }

        [Route("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("RoleList", "Role", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x=>x.Id == id);
            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
            {
                RoleId = value.Id,
                RoleName = value.Name
            };

            return View(updateRoleViewModel);
        }

        [HttpPost]
        [Route("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
            var value = _roleManager.Roles.FirstOrDefault(x=>x.Id==updateRoleViewModel.RoleId);
            value.Name = updateRoleViewModel.RoleName;

            await _roleManager.UpdateAsync(value);
            return RedirectToAction("RoleList", "Role", new { area = "Admin" });
        }

        [Route("UserList")]
        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        [Route("AssignRole/{id}")]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["x"] = user.Id;

            var roles = _roleManager.Roles.ToList();

            var userRoles = await _userManager.GetRolesAsync(user);

            List<AssignRoleViewModel> assignRoleViewModels = new List<AssignRoleViewModel>();

            foreach (var item in roles)
            {
                AssignRoleViewModel model = new AssignRoleViewModel()
                {
                    RoleId = item.Id,
                    RoleName = item.Name,
                    RoleExist = userRoles.Contains(item.Name)
                };

                assignRoleViewModels.Add(model);
            }

            return View(assignRoleViewModels);
        }

        [HttpPost]
        [Route("AssignRole/{id}")]
        public async Task<IActionResult> AssignRole(List<AssignRoleViewModel> model)
        {
            int userId = (int)TempData["x"];
            var user = _userManager.Users.FirstOrDefault(x=>x.Id == userId);

            foreach (var item in model)
            {
                if(item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }

                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("UserList", "Role",new {area="Admin"});

        }


    }
}
