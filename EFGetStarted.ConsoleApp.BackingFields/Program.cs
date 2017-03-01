using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace EFGetStarted.ConsoleApp.BackingFields
{
    public class Program
    {
        //By convention, the following fields will be discovered as backing fields for a given property (listed in precedence order). Fields are only discovered for properties that are included in the model. For more information on which properties are included in the model
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
            optionsBuilder.UseSqlServer("Server=DESKTOP-N3GTH4E\\SQLEXPRESS;Database=EFGetStarted.ConsoleApp.BackingFields;uid=sa;pwd=sasa;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
            .Property(b => b.Url)
            .HasField("_validatedUrl");
        }
    }
    
    public class Blog
    {
        private string _validatedUrl;
        
        public int BlogId
        {
            get;
            set;
        }
        
        public string Url
        {
            get
            {
                return _validatedUrl;
            }
        }
        
        public void SetUrl(string url)
        {
            using(var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
            }
            
            _validatedUrl = url;
        }
    }
}