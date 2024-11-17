using BlogForest.DtoLayer.CategoryDtos;
using BlogForest.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogForest.DataAccessLayer.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        List<Blog> GetBlogsWithCategoryAndUser();
        List<CategoryBlogCountDto> NumberOfBlogsByCategory();

        List<Blog> GetLast2BlogByAppUser(int id);
        List<Blog> GetBlogsByAppUser(int id);
        void IncreaseBlogViewCount(int id);
    }
}
