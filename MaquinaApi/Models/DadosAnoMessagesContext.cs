using Microsoft.EntityFrameworkCore;

namespace MaquinaApi.Models
{
    public class DadosAnoMessagesContext : DbContext
    {
        public DadosAnoMessagesContext(DbContextOptions<DadosAnoMessagesContext> options)
        : base(options)
        {
        }

        public DbSet<DadosAnoMessages> DadosAnoMessages { get; set; } = null!;
    }
}
