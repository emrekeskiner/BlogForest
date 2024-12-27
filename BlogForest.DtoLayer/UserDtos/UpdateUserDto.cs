using Microsoft.AspNetCore.Http;

namespace BlogForest.DtoLayer.UserDtos
{
    public class UpdateUserDto
    {
        public string? Name { get; set; } = String.Empty;
        public string? Surname { get; set; } = String.Empty;
        public string? ImageUrl { get; set; } = String.Empty;
        public string? Description { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string? Password { get; set; } = string.Empty;

        public IFormFile? Image { get; set; }
    }
}
