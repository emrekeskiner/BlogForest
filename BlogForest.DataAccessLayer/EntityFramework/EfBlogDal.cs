using BlogForest.DataAccessLayer.Abstract;
using BlogForest.DataAccessLayer.Context;
using BlogForest.DataAccessLayer.Repostories;
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

        public List<Blog> GetBlogsWithCategoryAndUser()
        {
            var values = _context.Blogs
                                    .Include(x=> x.Category)
                                    .Include(y=>y.AppUser)
                                    .ToList();
            return values;
        }
    }
}
