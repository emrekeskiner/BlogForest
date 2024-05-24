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
    public class EfCategoryDal : GenericRepostory<Category>, ICategoryDal
    {
        private readonly BlogContext _blogContext;
        public EfCategoryDal(BlogContext context) : base(context)
        {
            _blogContext = context;
        }

      
    }
}
