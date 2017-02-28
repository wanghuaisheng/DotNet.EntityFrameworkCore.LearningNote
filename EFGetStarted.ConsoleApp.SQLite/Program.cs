using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.ConsoleApp.SQLite
{
    public class Program
    {
        //1. dotnet ef migrations add MyFirstMigration
        public static void Main(string[] args)
        {
        }
    }
    
    public class BloggingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Blogging.db");
        }
    }
}