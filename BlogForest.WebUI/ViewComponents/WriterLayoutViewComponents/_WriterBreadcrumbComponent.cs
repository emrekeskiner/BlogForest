using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterBreadcrumbComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
