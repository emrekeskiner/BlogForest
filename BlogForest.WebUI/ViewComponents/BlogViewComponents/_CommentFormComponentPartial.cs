using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.BlogViewComponents
{
    public class _CommentFormComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
