using DataExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataExample
{
    public class DataExampleContext : DbContext
    {
        public DataExampleContext() { }
        public DataExampleContext(DbContextOptions<DataExampleContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<PostTags> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>(e =>
            {
                e.HasKey(u => u.Id);
                e.HasIndex(u => u.Name).IsUnique();
                e.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<Posts>(e =>
            {
                e.HasKey(p => p.Id);
                e.HasOne(p => p.User).WithMany(u => u.Posts).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Comments>(e =>
            {
                e.HasKey(c => c.Id);
                e.HasOne(c => c.User).WithMany(u => u.Comments).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(c => c.Post).WithMany(p => p.Comments).HasForeignKey(c => c.PostId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Tags>(e =>
            {
                e.HasKey(t => t.Id);
                e.HasIndex(t => t.Name).IsUnique();
            });

            modelBuilder.Entity<PostTags>(e =>
            {
                e.HasKey(pt => new { pt.PostId, pt.TagId });
                e.HasOne(pt => pt.Post).WithMany(p => p.PostTags).HasForeignKey(pt => pt.PostId);
                e.HasOne(pt => pt.Tag).WithMany(t => t.PostTags).HasForeignKey(pt => pt.TagId);
            });
        }
    }
}
