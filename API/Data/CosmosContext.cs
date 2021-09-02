using API.DocumentEntities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CosmosContext : DbContext
    {
        public DbSet<Valuation> Valuations { get; set; }
        public CosmosContext(DbContextOptions<CosmosContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("Valuations");

            modelBuilder.Entity<Valuation>()
            .OwnsOne(c => c.Vehicle);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}