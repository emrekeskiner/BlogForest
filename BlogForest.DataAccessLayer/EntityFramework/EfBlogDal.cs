using BlogForest.DataAccessLayer.Abstract;
using BlogForest.DataAccessLayer.Context;
using BlogForest.DataAccessLayer.Repostories;
using BlogForest.DtoLayer.CategoryDtos;
using BlogForest.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogForest.DataAccessLayer.EntityFramework
{
    public class EfBlogDal : GenericRepostory<Blog>, IBlogDal
    {
        private readonly BlogContext _context;
        public EfBlogDal(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<Blog> GetBlogsByAppUser(int id)
        {
           var values = _context.Blogs.Where(x=>x.AppUserId == id).Include(y=>y.Category).ToList();
            return values;
        }

        public List<Blog> GetBlogsWithCategoryAndUser()
        {
            var values = _context.Blogs
                                    .Include(x=> x.Category)
                                    .Include(y=>y.AppUser)
                                    .ToList();
            return values;
        }

        public List<Blog> GetLast2BlogByAppUser(int id)
        {
          int appUserId=_context.Blogs.Where(x=>x.BlogId == id).Select(y=>y.AppUserId).FirstOrDefault();
           var values = _context.Blogs.Where(x=>x.AppUserId == appUserId)
                .OrderByDescending(y=>y.BlogId).Take(2).ToList();
            return values;
        }

        public void IncreaseBlogViewCount(int id)
        {
            var value = _context.Blogs.Where(x=> x.BlogId == id).FirstOrDefault();
            value.ViewCount += 1;
            _context.Blogs.Update(value);
            _context.SaveChanges();
        }

        public List<CategoryBlogCountDto> NumberOfBlogsByCategory()
        {
            var categoryBlogCounts = _context.Categories
             .Select(c => new CategoryBlogCountDto
             {
                 CategoryName = c.CategoryName,
                 BlogCount = c.Blogs.Count
             })
             .ToList();

            return categoryBlogCounts;
        }


    }
}
