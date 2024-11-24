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
    public class EfIssueDal : GenericRepostory<Issue>, IIssueDal
    {
        private readonly BlogContext _context;

        public EfIssueDal(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<Issue> GetIssuesWithUser()
        {
            var value = _context.Issues
                .Include(x => x.ReportedByUser)
                .Include(y => y.AdminUser)
                .ToList();
            return value;
        }
    }
}
