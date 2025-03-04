﻿namespace BlogForest.EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? NameSurname { get; set; }
        public string? Detail { get; set; }
        public DateTime CommentDate { get; set; }= DateTime.Now;
        public bool Status { get; set; }=false;

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
