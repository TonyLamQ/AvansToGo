﻿using Microsoft.EntityFrameworkCore;
using Core.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure
{
    public class AvansToGoContext : DbContext
    {
        public AvansToGoContext(DbContextOptions<AvansToGoContext> options) : base(options)
        {
        }

        public DbSet<Canteen> Canteens { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Package> Packages { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            IEnumerable<Canteen> Canteens = new List<Canteen>
            {
                new Canteen
            {
                City = EnumCity.Breda,
                Location = "LA200",
                ServesHotMeals = true
            },
                new Canteen
            {
                City = EnumCity.Tilburg,
                Location = "LA300",
                ServesHotMeals = false
            },
                new Canteen
            {
                City = EnumCity.DenBosch,
                Location = "LA400",
                ServesHotMeals = true
            }
        };

            IEnumerable<Student> Students = new List<Student>
            {
                new Student{ UserName= "Peter", Email="Student@gmail.com", BirthDate= new DateTime(2000,3,3), City = EnumCity.Breda, PhoneNumber="0612344321", StudentId= 1 },
                new Student{ UserName= "Jan", Email="Jan@gmail.com", BirthDate= new DateTime(2003,1,8), City = EnumCity.DenBosch, PhoneNumber="0622344321", StudentId= 2 },
                new Student{ UserName= "Esrid", Email="Esrid@gmail.com", BirthDate= new DateTime(2002,7,5), City = EnumCity.Tilburg, PhoneNumber="0632344321", StudentId= 3 }
            };

            IEnumerable<Employee> Employees = new List<Employee>
            {
                new Employee{ EmployeeId= 1, UserName="Tim"}
            };

            IEnumerable<Product> Products = new List<Product>
            {
                new Product{ Name="Sauzijnenbroodje", ContainsAlcohol=false, ImageUrl="https://images0.persgroep.net/rcs/iicE-7D10ut18K6FnZtMYA2_z8k/diocontent/159715277/_focus/0.62/0.3/_fill/1200/630/?appId=21791a8992982cd8da851550a453bd7f&quality=0.7"},
                new Product{ Name="Worstenbroodje", ContainsAlcohol= false, ImageUrl="https://cdn.heelhollandbakt.nl/2022/05/vegan-worstenbroodjes-robert-enzo.jpg"},
                new Product{ Name="Red wine", ContainsAlcohol= true, ImageUrl="https://cdn-prod.medicalnewstoday.com/content/images/articles/300/300854/red-wine.jpg"},
                new Product{ Name="Orange juice", ContainsAlcohol=false, ImageUrl="https://www.smart-meals.nl/wp-content/uploads/2021/09/Versse-sinaasappelsap.jpg"}
            };

            IEnumerable<Package> Packages = new List<Package> {
            new Package { Name = "Test", City = EnumCity.Breda, StudentId= Students.ToList()[0].StudentId, Price = 10.00, ContainsAlcohol = true, CanteenLocation = Canteens.ToList()[0].Location},
            new Package { Name = "Test2", City = EnumCity.Tilburg, Price = 13.00, ContainsAlcohol = false, CanteenLocation = Canteens.ToList()[1].Location.ToString()},
            new Package { Name = "Test3", City = EnumCity.DenBosch, Price = 14.00, ContainsAlcohol = true, CanteenLocation = Canteens.ToList()[2].Location.ToString()}
            };

            //Packages.ToList()[0].Products.Add(Products.ToList()[0]);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Canteen>().HasData(Canteens);
            modelBuilder.Entity<Package>().HasData(Packages);
            modelBuilder.Entity<Employee>().HasData(Employees);
            modelBuilder.Entity<Student>().HasData(Students);
            modelBuilder.Entity<Product>().HasData(Products);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AvansToGoDB;MultipleActiveResultSets=true;");
        //    //optionsBuilder.UseSqlServer(@"Server=tcp:avanstogoserver.database.windows.net,1433;Initial Catalog=AvansToGoDB;Persist Security Info=False;User ID=TonyLamQ;Password={Jigglypuff@};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //}

    }

}