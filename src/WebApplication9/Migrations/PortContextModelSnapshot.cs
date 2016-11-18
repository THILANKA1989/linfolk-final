using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication9.Models;

namespace WebApplication9.Migrations
{
    [DbContext(typeof(PortContext))]
    partial class PortContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication9.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("JoinedDate");

                    b.Property<string>("LastName");

                    b.Property<int>("Level");

                    b.Property<string>("Occupation");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Province");

                    b.Property<string>("Street");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("WebApplication9.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<string>("CategoryUrl");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebApplication9.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("PublishedDate");

                    b.Property<string>("Title");

                    b.Property<int>("Views");

                    b.HasKey("ID");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("WebApplication9.Models.Stop", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Arrival");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int?>("TripID");

                    b.HasKey("ID");

                    b.HasIndex("TripID");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("WebApplication9.Models.Trip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("WebApplication9.Models.Post", b =>
                {
                    b.HasOne("WebApplication9.Models.Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication9.Models.Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication9.Models.Stop", b =>
                {
                    b.HasOne("WebApplication9.Models.Trip")
                        .WithMany("Stops")
                        .HasForeignKey("TripID");
                });
        }
    }
}
