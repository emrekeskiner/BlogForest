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
            ViewBag.userId = _blogService.TGetById(id).AppUserId;
            return View();
        }
    }
}
