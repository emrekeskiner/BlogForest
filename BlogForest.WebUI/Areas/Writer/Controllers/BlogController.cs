using BlogForest.BusinessLayer.Abstract;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IBlogService _blogService;

        public BlogController(UserManager<AppUser> userManager, IBlogService blogService)
        {
            _userManager = userManager;
            _blogService = blogService;
        }

        public async Task<IActionResult> MyBlogs()
        {


            if (User.Identity!.IsAuthenticated)
            {
                var value = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.user = value.FullName;
                var myBlogs = _blogService.TGetBlogsWithCategoryAndUser().Where(x => x.AppUserId == value.Id).ToList();
                return View(myBlogs);
            }

            return View();
        }
    }
}
