using Microsoft.EntityFrameworkCore;

namespace MaquinaApi.Models
{
    public class CoinsBoxContext : DbContext
    {
        public CoinsBoxContext(DbContextOptions<CoinsBoxContext> options)
        : base(options)
        {
        }

        public DbSet<CoinsBox> CoinsBox { get; set; } = null!;
    }
}
