namespace BlogForest.EntityLayer.Concrete
{
    public class Issue
    {
            public int IssueId { get; set; }
            public string Title { get; set; } 
            public string Description { get; set; } 
            public string? Response { get; set; }
            public bool IsResolved { get; set; } = false;
            public string? ResolutionDetails { get; set; } 
            public DateTime CreatedAt { get; set; } = DateTime.Now;
            public DateTime? ResolvedAt { get; set; } 
            public int ReportedByUserId { get; set; } 
            public string? AdminComments { get; set; }
            public int? AdminUserId { get; set; }
            public AppUser ReportedByUser { get; set; }
            public AppUser? AdminUser { get; set; }


    
    }
}
