using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterSidebarComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
