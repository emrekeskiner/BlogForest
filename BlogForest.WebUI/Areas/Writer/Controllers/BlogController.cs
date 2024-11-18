using AutoMapper;
using BlogForest.BusinessLayer.Abstract;
using BlogForest.DtoLayer.BlogDtos;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogForest.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    [Authorize]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public BlogController(UserManager<AppUser> userManager, IBlogService blogService, IMapper mapper, ICategoryService categoryService)
        {
            _userManager = userManager;
            _blogService = blogService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> MyBlogs()
        {


            if (User.Identity!.IsAuthenticated)
            {
                var value = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.user = value.FullName;
                var myBlogs = _blogService.TGetBlogsWithCategoryAndUser().Where(x => x.AppUserId == value.Id).OrderByDescending(x => x.CreatedDate).ToList();
                return View(myBlogs);
            }

            return View();
        }
        [HttpGet]
        public IActionResult CreateMyBlog()
        {
            List<SelectListItem> category = new List<SelectListItem>();
            category.Add(new SelectListItem
            {
                Text = "Kategori Seçiniz",
                Value = "",
                Selected = true
            });

            category.AddRange(from i in _categoryService.TGetListAll()
                              select new SelectListItem
                              {
                                  Text = i.CategoryName,
                                  Value = i.CategoryId.ToString()
                              });


            ViewBag.category = category;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMyBlog(CreateBlogDto createBlogDto)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            createBlogDto.AppUserId = values.Id;
            createBlogDto.CreatedDate = DateTime.Now;
            createBlogDto.ViewCount = 0;
            if (createBlogDto.CategoryId == null || createBlogDto.CategoryId == 0)
            {
                return View();
            }
            var blogValues = _mapper.Map<Blog>(createBlogDto);
            _blogService.TInsert(blogValues);
            return RedirectToAction("MyBlogs", "Blog", new { area = "Writer" });
        }

        [HttpGet("{id}")]
        public IActionResult UpdateMyBlog(int id)
        {
            List<SelectListItem> category = (from i in _categoryService.TGetListAll()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;

            var blog = _blogService.TGetById(id);

            var updateBlog = _mapper.Map<UpdateBlogDto>(blog);

            return View(updateBlog);
        }
        [HttpPost("{id}")]
        public IActionResult UpdateMyBlog(UpdateBlogDto updateBlogDto)
        {
            var blog = _mapper.Map<Blog>(updateBlogDto);

            _blogService.TUpdate(blog);

            return RedirectToAction("MyBlogs", "Blog", new { area = "Writer" });
        }
        [HttpGet("{id}")]
        public IActionResult DeleteMyBlog(int id)
        {
          
            _blogService.TDelete(id);
            return RedirectToAction("MyBlogs", "Blog", new { area = "Writer" });
        }

    }
}
