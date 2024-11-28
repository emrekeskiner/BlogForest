namespace BlogForest.DtoLayer.CommentDto
{
    public class ResultCommentDto
    {
        public int CommentId { get; set; }
        public string? NameSurname { get; set; }
        public string? Detail { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Status { get; set; }

        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
    }
}
