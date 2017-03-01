using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFGetStarted.ConsoleApp.RelationshipsPrincipalKey;

namespace EFGetStarted.ConsoleApp.RelationshipsPrincipalKey.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFGetStarted.ConsoleApp.RelationshipsPrincipalKey.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LicensePlate")
                        .IsRequired();

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.HasKey("CarId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("EFGetStarted.ConsoleApp.RelationshipsPrincipalKey.RecordOfSale", b =>
                {
                    b.Property<int>("RecordOfSaleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarLicensePlate");

                    b.Property<DateTime>("DateSold");

                    b.Property<decimal>("Price");

                    b.HasKey("RecordOfSaleId");

                    b.HasIndex("CarLicensePlate");

                    b.ToTable("RecordOfSale");
                });

            modelBuilder.Entity("EFGetStarted.ConsoleApp.RelationshipsPrincipalKey.RecordOfSale", b =>
                {
                    b.HasOne("EFGetStarted.ConsoleApp.RelationshipsPrincipalKey.Car", "Car")
                        .WithMany("SaleHistory")
                        .HasForeignKey("CarLicensePlate")
                        .HasPrincipalKey("LicensePlate");
                });
        }
    }
}
