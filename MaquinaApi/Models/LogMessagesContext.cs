using Microsoft.EntityFrameworkCore;

namespace MaquinaApi.Models
{
    public class LogMessagesContext : DbContext
    {
        public LogMessagesContext(DbContextOptions<LogMessagesContext> options)
        : base(options)
        {
        }

        public DbSet<LogMessages> LogMessages { get; set; } = null!;
    }
}
