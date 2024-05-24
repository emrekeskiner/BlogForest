using BlogForest.EntityLayer.Concrete;

namespace BlogForest.BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        public List<Blog> TGetBlogsWithCategoryAndUser();
    }
}
