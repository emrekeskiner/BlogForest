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
        public bool Status { get; set; } = false;

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Comment Comment { get; set; }
    }
}
