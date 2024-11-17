using BlogForest.EntityLayer.Concrete;
using BlogForest.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Controllers
{
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
				return RedirectToAction("RoleList");
			}
			return View();
		}

		public async Task<IActionResult> DeleteRole(int id)
		{
			var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
			await _roleManager.DeleteAsync(value);
			return RedirectToAction("RoleList");
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
			return RedirectToAction("RoleList");
		}

		public IActionResult UserList()
		{
			var values = _userManager.Users.ToList();
			return View(values);
		}
		[HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
           var user = _userManager.Users.FirstOrDefault(x=>x.Id == id);
			TempData["x"]= user.Id;
			var roles =  _roleManager.Roles.ToList();
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
				if(item.RoleExist) 
				{
					await _userManager.AddToRoleAsync(user, item.RoleName);
				}
				else
				{
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);

                }
			}
			return RedirectToAction("UserList");
		}
    }
}