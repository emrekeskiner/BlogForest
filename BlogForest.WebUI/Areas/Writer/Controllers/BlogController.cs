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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(UserManager<AppUser> userManager, IBlogService blogService, IMapper mapper, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _blogService = blogService;
            _mapper = mapper;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
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
        public JsonResult UploadCKEDITOR(IFormFile upload)
        {
            if (upload != null && upload.Length > 0)
            {
                var fileName = DateTime.Now.ToString("yyyyMMddHHmmss")+upload.FileName;
                var path= Path.Combine(Directory.GetCurrentDirectory(),_webHostEnvironment.WebRootPath,"uploads",fileName);
                var str = new FileStream(path, FileMode.Create);
                upload.CopyToAsync(str);
                var url = $"{"/uploads/"}{fileName}";
                return Json(new { uploaded = true,url });

            }
            return Json(new { path = "/uploads/" });
        }

        [HttpGet]
        public async Task<IActionResult> FileBrowserCKEDITOR(IFormFile upload)
        {
            var dir = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(),_webHostEnvironment.WebRootPath,"uploads"));
            ViewBag.fileInfo = dir.GetFiles();
            return View("FileBrowserCKEDITOR");
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

        [HttpGet("{id}")]
        public IActionResult ChangeStatusMyBlog(int id)
        {
            var getBlog= _blogService.TGetById(id);
            if (getBlog.Status == true)
            {
                getBlog.Status = false;
               
            }
            else
            {
                getBlog.Status= true;
            }
            _blogService.TUpdate(getBlog);
            return RedirectToAction("MyBlogs", "Blog", new { area = "Writer" });
        }

    }
}
