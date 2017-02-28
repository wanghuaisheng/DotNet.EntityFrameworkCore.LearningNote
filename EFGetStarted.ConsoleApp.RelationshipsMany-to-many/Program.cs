﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFGetStarted.ConsoleApp.RelationshipsMany_to_many
{
    //Add-Migration MyFirstMigration
    //Update-Database
    public class Program
    {
        //Many-to-many relationships without an entity class to represent the join table are not yet supported. However, you can represent a many-to-many relationship by including an entity class for the join table and mapping two separate one-to-many relationships.
        public static void Main(string[] args)
        {
        }
    }
    
    internal class MyContext : DbContext
    {
        public DbSet<Post> Posts
        {
            get;
            set;
        }
        
        public DbSet<Tag> Tags
        {
            get;
            set;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-N3GTH4E\\SQLEXPRESS;Database=EFGetStarted.ConsoleApp.RelationshipsMany-to-many;uid=sa;pwd=sasa;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>().HasKey(t => new
            {
                t.TagId,
                t.PostId
            });
            modelBuilder.Entity<PostTag>()
            .HasOne(c => c.Post)
            .WithMany(c => c.PostTags)
            .HasForeignKey(c => c.PostId);
            modelBuilder.Entity<PostTag>()
            .HasOne(c => c.Tag)
            .WithMany(c => c.PostTags)
            .HasForeignKey(c => c.TagId);
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
        
        public List<PostTag> PostTags
        {
            get;
            set;
        }
    }
    
    public class Tag
    {
        public string TagId
        {
            get;
            set;
        }
        
        public List<PostTag> PostTags
        {
            get;
            set;
        }
    }
    
    public class PostTag
    {
        public int PostId
        {
            get;
            set;
        }
        
        public Post Post
        {
            get;
            set;
        }
        
        public string TagId
        {
            get;
            set;
        }
        
        public Tag Tag
        {
            get;
            set;
        }
    }
}