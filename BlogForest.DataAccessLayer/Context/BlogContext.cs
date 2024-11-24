using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogForest.DataAccessLayer.Context
{
    public class BlogContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ultrabook;Initial Catalog=BlogDbForest;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ReportedByUser ile ilişki
            modelBuilder.Entity<Issue>()
                .HasOne(i => i.ReportedByUser)
                .WithMany(u => u.IssuesReported)
                .HasForeignKey(i => i.ReportedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // AdminUser ile ilişki
            modelBuilder.Entity<Issue>()
                .HasOne(i => i.AdminUser)
                .WithMany(u => u.IssuesResolved)
                .HasForeignKey(i => i.AdminUserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Issue> Issues { get; set; }
    }
}
