using BlogForest.DtoLayer.CategoryDtos;
using BlogForest.EntityLayer.Concrete;

namespace BlogForest.BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        public List<Blog> TGetBlogsWithCategoryAndUser();
        public List<CategoryBlogCountDto> TNumberOfBlogsByCategory();
    }
}
