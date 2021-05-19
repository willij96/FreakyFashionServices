﻿// <auto-generated />
using FreakyFashionServices.Catalog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FreakyFashionServices.Catalog.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210120133224_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FreakyFashionServices.Catalog.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArticleNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AvailableStock")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleNumber = "atq134",
                            AvailableStock = 1,
                            Description = "description1",
                            Name = "name1",
                            Price = 101
                        },
                        new
                        {
                            Id = 2,
                            ArticleNumber = "vdw234",
                            AvailableStock = 2,
                            Description = "description2",
                            Name = "name2",
                            Price = 102
                        },
                        new
                        {
                            Id = 3,
                            ArticleNumber = "opa554",
                            AvailableStock = 3,
                            Description = "description3",
                            Name = "name3",
                            Price = 103
                        },
                        new
                        {
                            Id = 4,
                            ArticleNumber = "ort578",
                            AvailableStock = 4,
                            Description = "description4",
                            Name = "name4",
                            Price = 104
                        },
                        new
                        {
                            Id = 5,
                            ArticleNumber = "ace548",
                            AvailableStock = 5,
                            Description = "description5",
                            Name = "name5",
                            Price = 105
                        },
                        new
                        {
                            Id = 6,
                            ArticleNumber = "pob789",
                            AvailableStock = 6,
                            Description = "description6",
                            Name = "name6",
                            Price = 106
                        },
                        new
                        {
                            Id = 7,
                            ArticleNumber = "acr467",
                            AvailableStock = 7,
                            Description = "description7",
                            Name = "name7",
                            Price = 107
                        },
                        new
                        {
                            Id = 8,
                            ArticleNumber = "pav356",
                            AvailableStock = 8,
                            Description = "description8",
                            Name = "name8",
                            Price = 108
                        },
                        new
                        {
                            Id = 9,
                            ArticleNumber = "zzz728",
                            AvailableStock = 9,
                            Description = "description9",
                            Name = "name9",
                            Price = 109
                        },
                        new
                        {
                            Id = 10,
                            ArticleNumber = "xxx823",
                            AvailableStock = 10,
                            Description = "description10",
                            Name = "name10",
                            Price = 110
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
