using BlogForest.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCommentsComponentPartial:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _BlogDetailCommentsComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.TGetCommentsByBlogId(id);
            ViewBag.commentSum = _commentService.TSumComments();
            return View(values);
        }

    }
}
