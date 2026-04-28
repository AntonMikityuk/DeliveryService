using Microsoft.EntityFrameworkCore;
using DeliveryService.Models;

namespace DeliveryService.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
    }
}
