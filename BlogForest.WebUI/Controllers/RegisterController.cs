﻿using BlogForest.DtoLayer.RegisterDtos;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateRegisterDto createRegisterDto)
        {
            AppUser appUser = new AppUser()
            {
                Name = createRegisterDto.Name,
                Surname = createRegisterDto.Surname,
                Email = createRegisterDto.Email,
                ImageUrl = createRegisterDto.ImageUrl,
                Description = createRegisterDto.Description,
                UserName = createRegisterDto.Username
            };

            var result =await _userManager.CreateAsync(appUser, createRegisterDto.Password);
            if (result.Succeeded) 
            {
                //Rol ekleme işlemi
                var roleResult = await _userManager.AddToRoleAsync(appUser, "Writer");

                if (roleResult.Succeeded)
                {
                    //Rol ekleme işlemi başarılı ise
                    return RedirectToAction("Index", "Default", new { area = "Writer" });
                }
                else
                {
                    foreach (var error in roleResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }


            }
            else
            {
                //kullanıcı ekleme işlemi başarısız ise
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
}
