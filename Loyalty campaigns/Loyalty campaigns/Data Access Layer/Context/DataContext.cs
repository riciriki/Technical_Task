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
    }
}
