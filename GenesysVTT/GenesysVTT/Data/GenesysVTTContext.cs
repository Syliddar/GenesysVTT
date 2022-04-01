using GenesysVTT.Data;
using Microsoft.EntityFrameworkCore;

namespace GenesysVTT.Data
{
    public class GenesysVTTContext : DbContext
    {
        public DbSet<Message> MessageLogs { get; set; }

        public GenesysVTTContext(DbContextOptions<GenesysVTTContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

    }
}
