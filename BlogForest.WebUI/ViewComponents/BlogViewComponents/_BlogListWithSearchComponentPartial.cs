using BlogForest.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogForest.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogListWithSearchComponentPartial:ViewComponent
    {
        private readonly IBlogService _blogService;

        public _BlogListWithSearchComponentPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke(string search)
        {
            
            var values = _blogService.TGetBlogsWithCategoryAndUser()
                .Where(x=> x.Title.ToLower().Contains(search.ToLower()) ||
                        x.Description.ToLower().Contains(search.ToLower()) ||
                        x.Category.CategoryName.ToLower().Contains(search.ToLower())).ToList();
                

            return View(values);

        }
    }
}
