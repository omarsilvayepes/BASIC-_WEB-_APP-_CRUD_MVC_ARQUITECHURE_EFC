﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppMVCArquitecture.Data;

#nullable disable

namespace WebApp.DataAcces.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231215210530_AddImageUrlFieldToProductTable")]
    partial class AddImageUrlFieldToProductTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApp.Models.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Billy Spark",
                            CategoryId = 1,
                            Description = "Description",
                            ISBN = "SW13465789",
                            ImageUrl = "",
                            ListPrice = 99.0,
                            Price = 98.0,
                            Price100 = 80.0,
                            Price50 = 85.0,
                            Title = "Fortune of time"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Billy Spark",
                            CategoryId = 2,
                            Description = "Description",
                            ISBN = "SW13465789",
                            ImageUrl = "",
                            ListPrice = 99.0,
                            Price = 98.0,
                            Price100 = 80.0,
                            Price50 = 85.0,
                            Title = "Fortune of time"
                        });
                });

            modelBuilder.Entity("WebAppMVCArquitecture.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Service"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Tecnology"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Transports"
                        });
                });

            modelBuilder.Entity("WebApp.Models.Models.Product", b =>
                {
                    b.HasOne("WebAppMVCArquitecture.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
