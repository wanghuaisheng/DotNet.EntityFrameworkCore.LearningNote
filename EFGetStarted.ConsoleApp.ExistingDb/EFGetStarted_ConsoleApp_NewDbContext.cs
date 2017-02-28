using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.ConsoleApp.ExistingDb
{
    public partial class EFGetStarted_ConsoleApp_NewDbContext : DbContext
    {
        public virtual DbSet<Blogs> Blogs
        {
            get;
            set;
        }
        
        public virtual DbSet<Posts> Posts
        {
            get;
            set;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-N3GTH4E\SQLEXPRESS;Database=EFGetStarted.ConsoleApp.NewDb;uid=sa;pwd=sasa;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blogs>(entity =>
            {
                entity.HasKey(e => e.BlogId)
                .HasName("PK_Blogs");
            });
            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId)
                .HasName("PK_Posts");
                entity.HasIndex(e => e.BlogId)
                .HasName("IX_Posts_BlogId");
                entity.HasOne(d => d.Blog)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.BlogId);
            });
        }
    }
}