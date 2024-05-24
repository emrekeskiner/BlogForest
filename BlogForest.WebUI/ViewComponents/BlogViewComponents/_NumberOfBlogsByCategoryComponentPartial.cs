using BlogForest.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.BlogViewComponents
{
    public class _NumberOfBlogsByCategoryComponentPartial:ViewComponent
    {
        private readonly IBlogService _blogService;

        public _NumberOfBlogsByCategoryComponentPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.TNumberOfBlogsByCategory();
            return View(values);
        }
    }
}
