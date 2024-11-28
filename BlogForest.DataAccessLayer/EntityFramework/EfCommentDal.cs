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
    public class EfCommentDal : GenericRepostory<Comment>, ICommentDal
    {
        private readonly BlogContext _blogContext;
       
        public EfCommentDal(BlogContext context) : base(context)
        {
            _blogContext = context;
        }

        public List<Comment> GetCommentsByBlogId(int id)
        {
            var values = _blogContext.Comments.Where(x=>x.BlogId == id && x.Status==true).ToList();
            return values;
        }

        public int SumComments(int id)
        {
            var value = _blogContext.Comments.Where(x=>x.BlogId==id && x.Status==true).Count();
            return value;
        }

        public List<Comment> GetCommentWithBlog()
        {
            var value = _blogContext.Comments.Include(x=>x.Blog).ToList();
            return value;
        }

    }
}
