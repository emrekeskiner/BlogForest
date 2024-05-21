using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.DefaultViewComponents
{
    public class _NavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
