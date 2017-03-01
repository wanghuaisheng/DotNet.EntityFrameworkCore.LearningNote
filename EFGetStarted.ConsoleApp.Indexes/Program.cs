using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.ConsoleApp.Indexes
{
    public class Program
    {
        //Indexes can not be created using data annotations.
        public static void Main(string[] args)
        {
        }
    }
    
    internal class MyContext : DbContext
    {
        public DbSet<Person> People
        {
            get;
            set;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-N3GTH4E\\SQLEXPRESS;Database=EFGetStarted.ConsoleApp.Indexes;uid=sa;pwd=sasa;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
            .HasIndex(p => new
            {
                p.FirstName,
                p.LastName
            });
        }
    }
    
    public class Person
    {
        public int PersonId
        {
            get;
            set;
        }
        
        public string FirstName
        {
            get;
            set;
        }
        
        public string LastName
        {
            get;
            set;
        }
    }
}