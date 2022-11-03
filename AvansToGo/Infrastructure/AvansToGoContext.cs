using Microsoft.EntityFrameworkCore;
using Core.Domain;

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

        

            IEnumerable<Package> Packages = new List<Package> {
            new Package { Name = "Test", City = EnumCity.Breda, Price = 10.00, ContainsAlcohol = true, CanteenLocation = Canteens.ToList()[0].Location.ToString()},
            new Package { Name = "Test2", City = EnumCity.Tilburg, Price = 13.00, ContainsAlcohol = false, CanteenLocation = Canteens.ToList()[1].Location.ToString()},
            new Package { Name = "Test3", City = EnumCity.DenBosch, Price = 14.00, ContainsAlcohol = true, CanteenLocation = Canteens.ToList()[2].Location.ToString()}
            };

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Canteen>().HasData(Canteens);
            modelBuilder.Entity<Package>().HasData(Packages);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AvansToGoDB;MultipleActiveResultSets=true;");
        //    //optionsBuilder.UseSqlServer(@"Server=tcp:avanstogoserver.database.windows.net,1433;Initial Catalog=AvansToGoDB;Persist Security Info=False;User ID=TonyLamQ;Password={Jigglypuff@};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //}
    }
}