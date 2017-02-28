using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFGetStarted.ConsoleApp.RelationshipsOne_to_one.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
            .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            modelBuilder.Entity("EFGetStarted.ConsoleApp.RelationshipsOne_to_one.Blog", b =>
            {
                b.Property<int>("BlogId")
                .ValueGeneratedOnAdd();
                b.Property<string>("Url");
                b.HasKey("BlogId");
                b.ToTable("Blogs");
            });
            modelBuilder.Entity("EFGetStarted.ConsoleApp.RelationshipsOne_to_one.BlogImage", b =>
            {
                b.Property<int>("BlogImageId")
                .ValueGeneratedOnAdd();
                b.Property<int>("BlogForeignKey");
                b.Property<string>("Caption");
                b.Property<byte[]>("Image");
                b.HasKey("BlogImageId");
                b.HasIndex("BlogForeignKey")
                .IsUnique();
                b.ToTable("BlogImages");
            });
            modelBuilder.Entity("EFGetStarted.ConsoleApp.RelationshipsOne_to_one.BlogImage", b =>
            {
                b.HasOne("EFGetStarted.ConsoleApp.RelationshipsOne_to_one.Blog", "Blog")
                .WithOne("BlogImage")
                .HasForeignKey("EFGetStarted.ConsoleApp.RelationshipsOne_to_one.BlogImage", "BlogForeignKey")
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}