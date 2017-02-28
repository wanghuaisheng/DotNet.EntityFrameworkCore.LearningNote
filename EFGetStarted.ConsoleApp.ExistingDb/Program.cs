using System;

namespace EFGetStarted.ConsoleApp.ExistingDb
{
    public class Program
    {
        //Scaffold-DbContext "Server=DESKTOP-N3GTH4E\SQLEXPRESS;Database=EFGetStarted.ConsoleApp.NewDb;uid=sa;pwd=sasa;" Microsoft.EntityFrameworkCore.SqlServer
        public static void Main(string[] args)
        {
            using(var db = new EFGetStarted_ConsoleApp_NewDbContext())
            {
                db.Blogs.Add(new Blogs { Url = "http://blogs.msdn.com/adonet" });
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
}