using BlogForest.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.UserViewComponents
{
    public class _AboutAuthorUserComponentPartial:ViewComponent
    {
        private readonly IAppUserService _appUserService;

        public _AboutAuthorUserComponentPartial(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _appUserService.TGetById(id);
            return View(values);
        }
    }
}
