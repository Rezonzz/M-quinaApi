using Microsoft.EntityFrameworkCore;

namespace MaquinaApi.Models
{
    public class DrinksContext : DbContext
    {
        public DrinksContext(DbContextOptions<DrinksContext> options)
        : base(options)
        {
        }

        public DbSet<Drinks> Drinks { get; set; } = null!;
    }
}
