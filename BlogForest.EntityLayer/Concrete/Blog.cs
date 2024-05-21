using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogForest.EntityLayer.Concrete
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public string? ThumbnailImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public int? ViewCount { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? Description { get; set; }


    }
}
