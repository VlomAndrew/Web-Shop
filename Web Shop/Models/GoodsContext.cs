using Microsoft.EntityFrameworkCore;

namespace Web_Shop.Models
{

    public class GoodsContext: DbContext, IGoodsContext
    {
        public DbSet<Item> Goods { get; set; }

        public DbSet<Order> Orders { get; set; }
        public GoodsContext(DbContextOptions<GoodsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}