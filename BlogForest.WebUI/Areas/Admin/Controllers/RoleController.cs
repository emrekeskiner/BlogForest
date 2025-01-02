using BlogForest.EntityLayer.Concrete;
using BlogForest.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Route("Admin/[controller]/[action]")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public RoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult RoleList()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            AppRole appRole = new AppRole()
            {
                Name = createRoleViewModel.RoleName
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("UserList", "Role", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            if (value is not null)
            {
                await _roleManager.DeleteAsync(value);
            }

            return RedirectToAction("UserList", "Role", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
            {
                RoleId = value.Id,
                RoleName = value.Name
            };
            return View(updateRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleViewModel.RoleId);
            value.Name = updateRoleViewModel.RoleName;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("UserList", "Role", new { area = "Admin" });
        }

        public IActionResult UserList()
        {
            // Kullanıcı ve roller listesi için bir model
            var userWithRoles = new List<UserWithRolesViewModel>();

            // Kullanıcıları döngü ile gezerek rolleri dahil et
            foreach (var user in _userManager.Users.ToList())
            {
                var roles = _userManager.GetRolesAsync(user).Result; // Roller asenkron çekiliyor
                userWithRoles.Add(new UserWithRolesViewModel
                {
                    UserId = user.Id,
                    Name = user.Name!,
                    Surname = user.Surname!,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = roles.ToList()
                });
            }

            return View(userWithRoles);
        }
        [HttpGet]
        public async Task<IActionResult> ResetPassword(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["x"] = user.Id;
            ViewBag.UserName = user.UserName;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            int UserId = (int)TempData["x"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == UserId);



            if (!string.IsNullOrEmpty(model.Password))
            {
                var passwordChangeResult = await _userManager.RemovePasswordAsync(user);
                if (passwordChangeResult.Succeeded)
                {
                    var addPasswordResult = await _userManager.AddPasswordAsync(user, model.Password);
                    if (!addPasswordResult.Succeeded)
                    {
                        foreach (var error in addPasswordResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View("ResetPassword", model);
                    }
                }
                else
                {
                    foreach (var error in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View("ResetPassword", model);
                }
            }

            return RedirectToAction("UserList", "Role", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["x"] = user.Id;
            ViewBag.UserName = user.UserName;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleId = item.Id;
                model.RoleName = item.Name;
                model.RoleExist = userRoles.Contains(item.Name);
                roleAssignViewModels.Add(model);
            }
            return View(roleAssignViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userId = (int)TempData["x"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach (var item in model)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);

                }
            }
            return RedirectToAction("UserList","Role", new { area = "Admin" });
        }
    }
}