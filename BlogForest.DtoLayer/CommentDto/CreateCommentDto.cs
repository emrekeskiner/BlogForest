namespace BlogForest.DtoLayer.CommentDto;

public class CreateCommentDto
{
    public string? NameSurname { get; set; }
    public string? Detail { get; set; }
    public DateTime CommentDate { get; set; } = DateTime.Now;
    public bool Status { get; set; } = false;

    public int BlogId { get; set; }
}
