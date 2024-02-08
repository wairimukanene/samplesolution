using Microsoft.EntityFrameworkCore;
using samplesolution.Models;

namespace samplesolution.Data
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
        {
        }

        public DbSet<Item> itemss { get; set; }
    }
}
