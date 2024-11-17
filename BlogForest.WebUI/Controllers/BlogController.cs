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
        
        public IActionResult BlogCategory(string id)
        {
            //CategoryName değer alıyor mu kontrol et.
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Category name is required.");
            }
            //Veriyi viewbag e al
            ViewBag.CategoryName = id;
            return View();
        }

        [HttpGet]
        public IActionResult BlogSearch(string search)
        {
            ViewBag.search = search;

            return View();
        }
    }
}
