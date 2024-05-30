using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogForest.DtoLayer.BlogDtos
{
	public class CreateBlogDto
	{
		public string Title { get; set; }
		public string ThumbnailImageUrl { get; set; }
		public DateTime CreatedDate { get; set; }
		public int ViewCount { get; set; }
		public string CoverImageUrl { get; set; }
		public string Description { get; set; }
		public int CategoryId { get; set; }
		public int AppUserId { get; set; }
	}
}
