using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult _WriterLayout()
        {
            return View();
        }
    }
}
