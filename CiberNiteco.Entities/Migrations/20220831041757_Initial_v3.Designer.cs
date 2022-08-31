﻿// <auto-generated />
using System;
using CiberNiteco.Entities.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CiberNiteco.Entities.Migrations
{
    [DbContext(typeof(CiberNitecoDbContext))]
    [Migration("20220831041757_Initial_v3")]
    partial class Initial_v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CiberNiteco.Entities.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Danh mục các đồ uống",
                            Name = "Đồ uống"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Danh mục các thực phẩm",
                            Name = "Đồ ăn"
                        });
                });

            modelBuilder.Entity("CiberNiteco.Entities.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Hà Nội",
                            Name = "Tạp hóa Minh Anh"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Bắc Ninh",
                            Name = "Siêu thị Kim Ngân"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Bắc Giang",
                            Name = "Nhà hàng Hùng Cường"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Vĩnh Phúc",
                            Name = "Nhà hàng Thu Cúc"
                        });
                });

            modelBuilder.Entity("CiberNiteco.Entities.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 20m,
                            CustomerId = 1,
                            OrderDate = new DateTime(2022, 8, 27, 0, 0, 0, 0, DateTimeKind.Local),
                            ProductId = 2
                        },
                        new
                        {
                            Id = 2,
                            Amount = 170m,
                            CustomerId = 3,
                            OrderDate = new DateTime(2022, 8, 28, 0, 0, 0, 0, DateTimeKind.Local),
                            ProductId = 1
                        });
                });

            modelBuilder.Entity("CiberNiteco.Entities.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Sản phẩm của Habeco",
                            Name = "Bia Trúc Bạch",
                            Price = 15000m,
                            Quantity = 1600m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Sản phẩm của Habeco",
                            Name = "Bia BOLD",
                            Price = 12000m,
                            Quantity = 1800m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Sản phẩm của MenVodka",
                            Name = "Chân gà vị cay - 30g",
                            Price = 9000m,
                            Quantity = 5000m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Sản phẩm của MenVodka",
                            Name = "Chân gà vị mật ong - 30g",
                            Price = 10000m,
                            Quantity = 4000m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "Sản phẩm của TH True Milk",
                            Name = "Sữa TH",
                            Price = 8000m,
                            Quantity = 5700m
                        });
                });

            modelBuilder.Entity("CiberNiteco.Entities.Entities.Order", b =>
                {
                    b.HasOne("CiberNiteco.Entities.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CiberNiteco.Entities.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CiberNiteco.Entities.Entities.Product", b =>
                {
                    b.HasOne("CiberNiteco.Entities.Entities.Category", "Category")
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
