using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFGetStarted.ConsoleApp.AlternateKeys;

namespace EFGetStarted.ConsoleApp.AlternateKeys.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20170301020452_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFGetStarted.ConsoleApp.AlternateKeys.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EFGetStarted.ConsoleApp.AlternateKeys.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlogUrl");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.HasIndex("BlogUrl");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EFGetStarted.ConsoleApp.AlternateKeys.Post", b =>
                {
                    b.HasOne("EFGetStarted.ConsoleApp.AlternateKeys.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogUrl")
                        .HasPrincipalKey("Url");
                });
        }
    }
}
