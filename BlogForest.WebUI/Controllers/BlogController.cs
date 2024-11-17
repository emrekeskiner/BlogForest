using BlogForest.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        public IActionResult BlogDetail(int id)
        {
            ViewBag.i = id;
            //ViewBag.userId = _blogService.TGetById(id).AppUserId;
            _blogService.TIncreaseBlogViewCount(id);
            return View();
        }

        public IActionResult BlogCategory(string CategoryName)
        {

            var value = _blogService.TGetBlogsWithCategoryAndUser().Where(x=>x.Category.CategoryName== CategoryName);
            return View(value);
        }
    }
}
