namespace BlogForest.DtoLayer.IssueDto
{
    public class CreateWriterIssueDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Response { get; set; }
        public bool IsResolved { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string ReportedByUserId { get; set; }
    }
}
