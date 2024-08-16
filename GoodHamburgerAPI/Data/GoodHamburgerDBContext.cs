using GoodHamburgerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburgerAPI.Data
{
    public class GoodHamburgerDBContext : DbContext
    {
       public GoodHamburgerDBContext(DbContextOptions<GoodHamburgerDBContext>options)
            : base(options) 
        { 
        }
        public DbSet<Sandwich> Sandwiches { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Order> Orders { get; set; }
        
    }
}
