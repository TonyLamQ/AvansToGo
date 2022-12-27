﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AvansToGoContext))]
    [Migration("20221110185952_FillProducts")]
    partial class FillProducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Domain.Canteen", b =>
                {
                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<bool?>("ServesHotMeals")
                        .HasColumnType("bit");

                    b.HasKey("Location");

                    b.ToTable("Canteens");

                    b.HasData(
                        new
                        {
                            Location = "LA200",
                            City = 0,
                            ServesHotMeals = true
                        },
                        new
                        {
                            Location = "LA300",
                            City = 2,
                            ServesHotMeals = false
                        },
                        new
                        {
                            Location = "LA400",
                            City = 1,
                            ServesHotMeals = true
                        });
                });

            modelBuilder.Entity("Core.Domain.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            UserName = "Tim"
                        });
                });

            modelBuilder.Entity("Core.Domain.Package", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CanteenLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<bool>("ContainsAlcohol")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PickUpTimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PickUpTimeStart")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("CanteenLocation");

                    b.HasIndex("StudentId");

                    b.ToTable("Packages");

                    b.HasData(
                        new
                        {
                            Name = "Test",
                            CanteenLocation = "LA200",
                            City = 0,
                            ContainsAlcohol = true,
                            Price = 10.0,
                            StudentId = 1
                        },
                        new
                        {
                            Name = "Test2",
                            CanteenLocation = "LA300",
                            City = 2,
                            ContainsAlcohol = false,
                            Price = 13.0
                        },
                        new
                        {
                            Name = "Test3",
                            CanteenLocation = "LA400",
                            City = 1,
                            ContainsAlcohol = true,
                            Price = 14.0
                        });
                });

            modelBuilder.Entity("Core.Domain.Product", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("ContainsAlcohol")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.HasIndex("PackageName");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Name = "Sauzijnenbroodje",
                            ContainsAlcohol = false,
                            ImageUrl = "https://images0.persgroep.net/rcs/iicE-7D10ut18K6FnZtMYA2_z8k/diocontent/159715277/_focus/0.62/0.3/_fill/1200/630/?appId=21791a8992982cd8da851550a453bd7f&quality=0.7"
                        },
                        new
                        {
                            Name = "Worstenbroodje",
                            ContainsAlcohol = false,
                            ImageUrl = "https://cdn.heelhollandbakt.nl/2022/05/vegan-worstenbroodjes-robert-enzo.jpg"
                        },
                        new
                        {
                            Name = "Red wine",
                            ContainsAlcohol = true,
                            ImageUrl = "https://cdn-prod.medicalnewstoday.com/content/images/articles/300/300854/red-wine.jpg"
                        },
                        new
                        {
                            Name = "Orange juice",
                            ContainsAlcohol = false,
                            ImageUrl = "https://www.smart-meals.nl/wp-content/uploads/2021/09/Versse-sinaasappelsap.jpg"
                        });
                });

            modelBuilder.Entity("Core.Domain.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            BirthDate = new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = 0,
                            Email = "Student@gmail.com",
                            PhoneNumber = "0612344321",
                            UserName = "Peter"
                        },
                        new
                        {
                            StudentId = 2,
                            BirthDate = new DateTime(2003, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = 1,
                            Email = "Jan@gmail.com",
                            PhoneNumber = "0622344321",
                            UserName = "Jan"
                        },
                        new
                        {
                            StudentId = 3,
                            BirthDate = new DateTime(2002, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = 2,
                            Email = "Esrid@gmail.com",
                            PhoneNumber = "0632344321",
                            UserName = "Esrid"
                        });
                });

            modelBuilder.Entity("Core.Domain.Package", b =>
                {
                    b.HasOne("Core.Domain.Canteen", "Canteen")
                        .WithMany()
                        .HasForeignKey("CanteenLocation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Student", "ReservedBy")
                        .WithMany("Packages")
                        .HasForeignKey("StudentId");

                    b.Navigation("Canteen");

                    b.Navigation("ReservedBy");
                });

            modelBuilder.Entity("Core.Domain.Product", b =>
                {
                    b.HasOne("Core.Domain.Package", null)
                        .WithMany("Products")
                        .HasForeignKey("PackageName");
                });

            modelBuilder.Entity("Core.Domain.Package", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Core.Domain.Student", b =>
                {
                    b.Navigation("Packages");
                });
#pragma warning restore 612, 618
        }
    }
}
