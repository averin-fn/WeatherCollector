using Microsoft.EntityFrameworkCore;
using WeatherCollector.Entities;

namespace WeatherCollector.Context
{
    public class WeatherCollectorDb : DbContext
    {
        public DbSet<Weather> Weathers { get; set; }

        public WeatherCollectorDb(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Weather>()
                .HasKey(w => new { w.Date, w.Time });
        }
    }
}
