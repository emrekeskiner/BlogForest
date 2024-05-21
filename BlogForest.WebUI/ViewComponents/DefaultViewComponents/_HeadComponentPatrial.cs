using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.DefaultViewComponents
{
    public class _HeadComponentPatrial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
