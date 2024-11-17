using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterFooterComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
