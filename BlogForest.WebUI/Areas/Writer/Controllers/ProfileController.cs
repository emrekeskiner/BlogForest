
using AutoMapper;
using BlogForest.DtoLayer.UserDtos;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ProfileController(UserManager<AppUser> userManager, IMapper mapper, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _mapper = mapper;
            _env = env;
        }

        public async Task<IActionResult> UpdateProfile()
        {
            var user =await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();

            var userDto = _mapper.Map<UpdateUserDto>(user);

            return View(userDto);
            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateProfile", model);
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();

           
            _mapper.Map(model, user);

           
            if (model.Image != null)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }

                user.ImageUrl = $"/images/{uniqueFileName}";
            }
            else
            {
                user.ImageUrl = model.ImageUrl;
            }

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
                        return View("UpdateProfile", model);
                    }
                }
                else
                {
                    foreach (var error in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View("UpdateProfile", model);
                }
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["Success"] = "Profile updated successfully.";
                return RedirectToAction("UpdateProfile");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("UpdateProfile", model);
        }
    }
}

