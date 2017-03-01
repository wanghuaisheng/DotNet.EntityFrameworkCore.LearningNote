using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFGetStarted.ConsoleApp.Inheritance;

namespace EFGetStarted.ConsoleApp.Inheritance.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20170301020809_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFGetStarted.ConsoleApp.Inheritance.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Url");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Blog");
                });

            modelBuilder.Entity("EFGetStarted.ConsoleApp.Inheritance.RssBlog", b =>
                {
                    b.HasBaseType("EFGetStarted.ConsoleApp.Inheritance.Blog");

                    b.Property<string>("RssUrl");

                    b.ToTable("RssBlog");

                    b.HasDiscriminator().HasValue("RssBlog");
                });
        }
    }
}
