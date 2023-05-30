using Microsoft.EntityFrameworkCore;

namespace MaquinaApi.Models
{
    public class DadosDiaMessagesContext : DbContext
    {
        public DadosDiaMessagesContext(DbContextOptions<DadosDiaMessagesContext> options)
        : base(options)
        {
        }

        public DbSet<DadosDiaMessages> DadosDiaMessages { get; set; } = null!;
    }
}
