namespace BlogForest.DtoLayer.IssueDto
{
    public class UpdateWriterIssueDto
    {
        public int IssueId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Response { get; set; }
        public bool IsResolved { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public string ReportedByUserId { get; set; }
    }
}
