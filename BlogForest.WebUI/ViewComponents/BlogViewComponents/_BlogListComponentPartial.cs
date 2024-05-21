using BlogForest.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace BlogForest.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogListComponentPartial:ViewComponent
    {
        private readonly IBlogService _blogService;

        public _BlogListComponentPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _blogService.TGetListAll();
            return View(value);
        }
    }
}
