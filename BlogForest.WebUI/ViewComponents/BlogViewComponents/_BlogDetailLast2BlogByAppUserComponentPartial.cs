using BlogForest.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.BlogViewComponents
{
    
    public class _BlogDetailLast2BlogByAppUserComponentPartial:ViewComponent
    {
        private readonly IBlogService _blogService;

        public _BlogDetailLast2BlogByAppUserComponentPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _blogService.TGetLast2BlogByAppUser(id).Where(x=>x.Status==true);
            return View(values);
        }
    }
}
