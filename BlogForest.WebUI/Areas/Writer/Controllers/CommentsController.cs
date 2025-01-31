using AutoMapper;
using BlogForest.BusinessLayer.Abstract;
using BlogForest.DtoLayer.BlogDtos;
using BlogForest.DtoLayer.CommentDto;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class CommentsController:Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public CommentsController(ICommentService commentService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult CommentsList()
        {
            var userId =int.Parse(_userManager.GetUserId(User));


            var values = _commentService.TGetCommentWithBlog()
                .Where(x => x.Blog.AppUserId == userId)
                .ToList();

            var commentValues = _mapper.Map<List<ResultCommentDto>>(values);
            return View(commentValues);
        }

        [HttpGet]
        public IActionResult ChangeStatusComment(int id)
        {
            var comment = _commentService.TGetById(id);
            if (comment.Status == false)
            {
                comment.Status = true;
            }
            else
            {
                comment.Status = false;
            }
            _commentService.TUpdate(comment);
            return RedirectToAction("CommentsList", "Comments", new { area = "Writer" });
        }

    }
}
