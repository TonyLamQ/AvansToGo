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
    [Migration("20221109132901_FKStudentPackage")]
    partial class FKStudentPackage
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

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("CanteenLocation");

                    b.HasIndex("StudentId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("Core.Domain.Product", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("ContainsAlcohol")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.HasIndex("PackageName");

                    b.ToTable("Products");
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
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
