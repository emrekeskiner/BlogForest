﻿using BlogForest.DataAccessLayer.Abstract;
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
    public class EfCommentDal : GenericRepostory<Comment>, ICommentDal
    {
        public EfCommentDal(BlogContext context) : base(context)
        {
        }
    }
}
