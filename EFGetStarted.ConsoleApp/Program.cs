using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EFGetStarted.ConsoleApp
{
    public class Program
    {
        //Add-Migration MyFirstMigration/Remove-Migration
        //Update-Database
        public static void Main(string[] args)
        {
            using(var db = new BloggingContext())
            {
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);
                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                
                foreach(var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }
            }
        }
    }
    
    public class BloggingContext : DbContext
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
            optionsBuilder.UseSqlServer("Server=DESKTOP-N3GTH4E\\SQLEXPRESS;Database=EFGetStarted.ConsoleApp.NewDb;uid=sa;pwd=sasa;");
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
        
        public int BlogId
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