using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.ConsoleApp.Inheritance
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
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-N3GTH4E\\SQLEXPRESS;Database=EFGetStarted.ConsoleApp.Inheritance;uid=sa;pwd=sasa;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RssBlog>();
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
    }
    
    public class RssBlog : Blog
    {
        public string RssUrl
        {
            get;
            set;
        }
    }
}