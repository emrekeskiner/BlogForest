using AutoMapper;
using BlogForest.DtoLayer.BlogDtos;
using BlogForest.EntityLayer.Concrete;

namespace BlogForest.WebUI.Mapping
{
	public class GeneralMapping:Profile
	{
        public GeneralMapping()
        {
            CreateMap<Blog, CreateBlogDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogDto>().ReverseMap();
        }
    }
}
