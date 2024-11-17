using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BlogForest.WebUI.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterNavbarComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _WriterNavbarComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.FullName.ToLower());
            ViewBag.userImage = value.ImageUrl;
            return View();
        }
    
    }
}
