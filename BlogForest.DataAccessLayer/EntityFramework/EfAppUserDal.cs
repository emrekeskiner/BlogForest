using BlogForest.DataAccessLayer.Abstract;
using BlogForest.DataAccessLayer.Context;
using BlogForest.DataAccessLayer.Repostories;
using BlogForest.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogForest.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepostory<AppUser>, IAppUserDal
    {
        private readonly BlogContext _blogContext;
        public EfAppUserDal(BlogContext context) : base(context)
        {
            _blogContext = context;
        }

        public AppUser GetAppUserDetail(int id)
        {
            var value = _blogContext.Blogs.Where(x => x.BlogId == id).Select(y=>y.AppUser).FirstOrDefault();
            return value;
        }
    }
}
