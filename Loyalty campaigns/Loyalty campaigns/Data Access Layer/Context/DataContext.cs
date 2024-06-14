using Loyalty_campaigns.Models;
using Microsoft.EntityFrameworkCore;

namespace Loyalty_campaigns.Data_Access_Layer.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(k => k.Reward)
                .WithOne(n => n.Customer)
                .HasForeignKey<Reward>(n => n.CustomerId);

            modelBuilder.Entity<Reward>()
                .HasOne(n => n.Employee)
                .WithMany(z => z.Rewards)
                .HasForeignKey(n => n.EmployeeId);

            modelBuilder.Entity<Purchase>()
                .HasOne(k => k.Customer)
                .WithMany(c => c.Purchases)
                .HasForeignKey(k => k.CustomerId);

            modelBuilder.Entity<Employee>()
            .HasOne(e => e.Role)
            .WithMany(r => r.Employees)
            .HasForeignKey(e => e.RoleId)
            .IsRequired();
        }

    }
}
