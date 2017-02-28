using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.ConsoleApp.RelationshipsOne_to_one
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
    
    internal class MyContext : DbContext
    {
        public DbSet<Blog> Blogs
        {
            get;
            set;
        }
        
        public DbSet<BlogImage> BlogImages
        {
            get;
            set;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-N3GTH4E\\SQLEXPRESS;Database=EFGetStarted.ConsoleApp.RelationshipsOne-to-one;uid=sa;pwd=sasa;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
            .HasOne(c => c.BlogImage)
            .WithOne(c => c.Blog)
            .HasForeignKey<BlogImage>(c => c.BlogForeignKey);
        }
    }
    
    public class Blog
    {
        public int BlogId
        {
            get;
            set;
        }
        
        public string Url
        {
            get;
            set;
        }
        
        public BlogImage BlogImage
        {
            get;
            set;
        }
    }
    
    public class BlogImage
    {
        public int BlogImageId
        {
            get;
            set;
        }
        
        public byte[] Image
        {
            get;
            set;
        }
        
        public string Caption
        {
            get;
            set;
        }
        
        public int BlogForeignKey
        {
            get;
            set;
        }
        
        public Blog Blog
        {
            get;
            set;
        }
    }
}