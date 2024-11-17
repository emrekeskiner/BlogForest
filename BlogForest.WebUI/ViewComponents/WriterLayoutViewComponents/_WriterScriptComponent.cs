using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterScriptComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
