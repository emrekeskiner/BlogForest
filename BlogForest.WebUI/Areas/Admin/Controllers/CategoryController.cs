using BlogForest.BusinessLayer.Abstract;
using BlogForest.DtoLayer.CategoryDtos;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult CategoryList()
        {
            
            var values = _categoryService.TGetListAll();

            var categoryDto = values.Select(x => new CategoryResultDto
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList();

            return View(categoryDto);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    CategoryName = categoryDto.CategoryName
                };
                _categoryService.TInsert(category);
                return RedirectToAction("CategoryList", "Category", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        public IActionResult DeleteCategory(int id)
        {
           
            _categoryService.TDelete(id);
            return RedirectToAction("CategoryList", "Category", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _categoryService.TGetById(id);
            var categoryDto = new UpdateCategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
            return View(categoryDto);
        }

        [HttpPost]
        public IActionResult UpdateCategory(UpdateCategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    CategoryId = categoryDto.CategoryId,
                    CategoryName = categoryDto.CategoryName
                };
                _categoryService.TUpdate(category);
                return RedirectToAction("CategoryList", "Category", new { area = "Admin" });
            }
            return View();
        }
    }
}
