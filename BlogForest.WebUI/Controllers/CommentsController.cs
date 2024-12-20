using AutoMapper;
using BlogForest.BusinessLayer.Abstract;
using BlogForest.DtoLayer.CommentDto;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace BlogForest.WebUI.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateComment([FromForm] CreateCommentDto commentDto)
        {
            if(ModelState.IsValid)
            {
               var commentMap = _mapper.Map<Comment>(commentDto);
                _commentService.TInsert(commentMap);
                return RedirectToAction("Index","Default");

            }

            return View();
           // throw new Exception(message: "Yorum kaydedilirken bir hata oluştu.");
        }
    }
}
