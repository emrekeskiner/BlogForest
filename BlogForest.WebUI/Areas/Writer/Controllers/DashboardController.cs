using BlogForest.BusinessLayer.Abstract;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IBlogService blogService, UserManager<AppUser> userManager)
        {
            _blogService = blogService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.blogCount = _blogService.TGetBlogsWithCategoryAndUser().Count();
            ViewBag.myBlogCount = _blogService.TGetBlogsWithCategoryAndUser().Where(x=>x.AppUserId== user.Id).Count();
            ViewBag.myBlogSumView = _blogService.TGetBlogsWithCategoryAndUser().Where(x=>x.AppUserId== user.Id).Sum(x=>x.ViewCount);

            var blogs = _blogService.TGetBlogsWithCategoryAndUser()
                .Where(x=>x.AppUserId== user.Id)
                .OrderByDescending(x=>x.ViewCount)
                .Take(3)
                .ToList();
            return View(blogs);
        }
    }
}
