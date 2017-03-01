using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFGetStarted.ConsoleApp.AlternateKeys
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
        
        public DbSet<Post> Posts
        {
            get;
            set;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-N3GTH4E\\SQLEXPRESS;Database=EFGetStarted.ConsoleApp.AlternateKeys;uid=sa;pwd=sasa;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Post>()
            //.HasOne(p => p.Blog)
            //.WithMany(b => b.Posts)
            //.HasForeignKey(p => p.BlogUrl)
            //.HasPrincipalKey(b => b.Url);
            modelBuilder.Entity<Blog>()
            .HasMany(c => c.Posts)
            .WithOne(c => c.Blog)
            .HasForeignKey(c => c.BlogUrl)
            .HasPrincipalKey(c => c.Url);
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
        
        public List<Post> Posts
        {
            get;
            set;
        }
    }
    
    public class Post
    {
        public int PostId
        {
            get;
            set;
        }
        
        public string Title
        {
            get;
            set;
        }
        
        public string Content
        {
            get;
            set;
        }
        
        public string BlogUrl
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