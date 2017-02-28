﻿using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.ConsoleApp.SQLite
{
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
            optionsBuilder.UseSqlite("Filename=./Blogging.db");
        }
    }
}