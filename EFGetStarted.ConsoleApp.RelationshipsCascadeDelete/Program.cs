using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace EFGetStarted.ConsoleApp.RelationshipsCascadeDelete
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
            optionsBuilder.UseSqlServer("Server=DESKTOP-N3GTH4E\\SQLEXPRESS;Database=EFGetStarted.ConsoleApp.RelationshipsCascadeDelete;uid=sa;pwd=sasa;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Post>()
            //.HasOne(p => p.Blog)
            //.WithMany(b => b.Posts)
            //.OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Blog>()
            .HasMany(c => c.Posts)
            .WithOne(c => c.Blog)
            .HasForeignKey(c => c.BlogId)
            .OnDelete(DeleteBehavior.Cascade);
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
        
        public int? BlogId
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