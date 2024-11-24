namespace BlogForest.DtoLayer.IssueDto
{
    public class ResultIssueDto
    {
        public int IssueId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Response { get; set; }
        public bool IsResolved { get; set; } = false;
        public string? ResolutionDetails { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public string ReportedByUserId { get; set; }
        public string? AdminComments { get; set; }
        public string? AdminUserId { get; set; }
        public int AppUserId { get; set; }
        public string? ReportedByUser { get; set; }
        public string? AdminUser { get; set; }
        public string? AdminFullName { get; set; } // Yeni özellik
    }
}
