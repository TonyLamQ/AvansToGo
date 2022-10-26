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
            IEnumerable<Package> packages = new List<Package> {
            new Package { Name = "Test", Price = 10.00 } };

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Package>().HasData(packages);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AvansToGoDB;MultipleActiveResultSets=true;");
        //    //optionsBuilder.UseSqlServer(@"Server=tcp:avanstogoserver.database.windows.net,1433;Initial Catalog=AvansToGoDB;Persist Security Info=False;User ID=TonyLamQ;Password={Jigglypuff@};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //}
    }
}