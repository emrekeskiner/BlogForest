using AutoMapper;
using BlogForest.DtoLayer.BlogDtos;
using BlogForest.DtoLayer.CommentDto;
using BlogForest.DtoLayer.IssueDto;
using BlogForest.EntityLayer.Concrete;

namespace BlogForest.WebUI.Mapping
{
	public class GeneralMapping:Profile
	{
        public GeneralMapping()
        {
            CreateMap<Blog, CreateBlogDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogDto>().ReverseMap();
            CreateMap<Issue, ResultIssueDto>()
     .ForMember(dest => dest.ReportedByUser, opt => opt.MapFrom(src => src.ReportedByUser.UserName))
     .ForMember(dest => dest.AdminUser, opt => opt.MapFrom(src => src.AdminUser != null ? src.AdminUser.UserName : null))
     .ForMember(dest => dest.AdminFullName, opt => opt.MapFrom(src => src.AdminUser != null ? src.AdminUser.Name + " " + src.AdminUser.Surname : null));
            CreateMap<Issue, CreateWriterIssueDto>().ReverseMap();
            CreateMap<Issue, UpdateWriterIssueDto>().ReverseMap();

            CreateMap<Comment, ResultCommentDto>().ForMember(dest=> dest.BlogTitle, opt => opt.MapFrom(src =>src.Blog.Title));
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
        }
    }
}
