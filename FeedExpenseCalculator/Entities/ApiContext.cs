using FeedExpenseCalculator.Service.Entities.FeedData;
using Microsoft.EntityFrameworkCore;

namespace FeedExpenseCalculator.Service.Entities
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
             (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "FeedDb");
        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Food> Food { get; set; }
    }
}
