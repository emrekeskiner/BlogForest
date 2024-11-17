using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents._WriterHeaderComponent
{
    public class _WriterHeaderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
