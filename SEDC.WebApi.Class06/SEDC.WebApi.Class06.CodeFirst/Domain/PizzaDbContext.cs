using Microsoft.EntityFrameworkCore;
using SEDC.WebApi.Class06.CodeFirst.Domain.Mappings;

namespace SEDC.WebApi.Class06.CodeFirst.Domain
{
    public class PizzaDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaType> PizzaTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\MSSQLlocaldb;Database=PizzaDBCodeFirst");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.Entity<User>()
                .HasData
                (
                    new User
                    {
                        Id = 1,
                        Name = "Trajan",
                        Address = "Temnica",
                        City = "Skopje",
                        Email = "a@b.com.mk"
                    }
                );
        }
    }
}
