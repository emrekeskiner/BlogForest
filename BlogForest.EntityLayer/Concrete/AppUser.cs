using Microsoft.AspNetCore.Identity;

namespace BlogForest.EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }

        public List<Blog> Blogs{ get; set; }
        public List<Issue> Issues{ get; set; }
        public string FullName => string.Join(" ", Name, Surname);
    }
}
