namespace BlogForest.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
