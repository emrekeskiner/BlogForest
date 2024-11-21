namespace BlogForest.DtoLayer.IssueDto
{
    public class UpdateAdminIssueDto
    {
        public int IssueId { get; set; }
        public string? Response { get; set; }
        public bool IsResolved { get; set; }
        public string? ResolutionDetails { get; set; }
        public DateTime? ResolvedAt { get; set; } =DateTime.Now;
        public string? AdminComments { get; set; }
        public string? AdminUserId { get; set; }
    }
}
