using BlogForest.BusinessLayer.Abstract;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogListWithCategoryComponentPartial:ViewComponent
    {
        private readonly IBlogService _blogService;

        public _BlogListWithCategoryComponentPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke(string CategoryName)
        {
       
                var values = _blogService.TGetBlogsWithCategoryAndUser().Where(x=> x.Category.CategoryName == CategoryName).ToList();
            return View(values);

        }
    }
}
