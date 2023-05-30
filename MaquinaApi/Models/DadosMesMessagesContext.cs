using Microsoft.EntityFrameworkCore;

namespace MaquinaApi.Models
{
    public class DadosMesMessagesContext : DbContext
    {
        public DadosMesMessagesContext(DbContextOptions<DadosMesMessagesContext> options)
        : base(options)
        {
        }

        public DbSet<DadosMesMessages> DadosMesMessages { get; set; } = null!;
    }
}
