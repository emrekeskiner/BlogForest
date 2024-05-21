using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.DefaultViewComponents
{
    public class _TopbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
