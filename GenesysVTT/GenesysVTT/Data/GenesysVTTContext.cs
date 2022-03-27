using GenesysVTT.Data;
using Microsoft.EntityFrameworkCore;

namespace GenesysVTT.Data
{
    public class GenesysVTTContext : DbContext
    {
        public DbSet<MessageLog> MessageLogs { get; set; }

        public GenesysVTTContext(DbContextOptions<GenesysVTTContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

    }
}
