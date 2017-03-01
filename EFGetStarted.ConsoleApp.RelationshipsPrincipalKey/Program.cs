using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EFGetStarted.ConsoleApp.RelationshipsPrincipalKey
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
    
    internal class MyContext : DbContext
    {
        public DbSet<Car> Cars
        {
            get;
            set;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-N3GTH4E\\SQLEXPRESS;Database=EFGetStarted.ConsoleApp.RelationshipsPrincipalKey;uid=sa;pwd=sasa;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<RecordOfSale>()
            //.HasOne(s => s.Car)
            //.WithMany(c => c.SaleHistory)
            //.HasForeignKey(s => s.CarLicensePlate)
            //.HasPrincipalKey(c => c.LicensePlate);
            modelBuilder.Entity<Car>()
            .HasMany(c => c.SaleHistory)
            .WithOne(c => c.Car)
            .HasForeignKey(c => c.CarLicensePlate)
            .HasPrincipalKey(c => c.LicensePlate);
        }
    }
    
    public class Car
    {
        public int CarId
        {
            get;
            set;
        }
        
        public string LicensePlate
        {
            get;
            set;
        }
        
        public string Make
        {
            get;
            set;
        }
        
        public string Model
        {
            get;
            set;
        }
        
        public List<RecordOfSale> SaleHistory
        {
            get;
            set;
        }
    }
    
    public class RecordOfSale
    {
        public int RecordOfSaleId
        {
            get;
            set;
        }
        
        public DateTime DateSold
        {
            get;
            set;
        }
        
        public decimal Price
        {
            get;
            set;
        }
        
        public string CarLicensePlate
        {
            get;
            set;
        }
        
        public Car Car
        {
            get;
            set;
        }
    }
}