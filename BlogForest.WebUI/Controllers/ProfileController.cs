using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        public IActionResult UserProfile()
        {
            return View();
        }
    }
}
