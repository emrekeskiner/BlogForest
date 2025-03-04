﻿using BlogForest.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.BlogViewComponents
{
    public class _RecentPostComponentPartial:ViewComponent
    {
        private readonly IBlogService _blogService;

        public _RecentPostComponentPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.TGetListAll().Where(x=>x.Status==true)
                                .OrderByDescending(x=>x.BlogId)
                                .Take(3)
                                .ToList();
            return View(values);
        }
    }
}
