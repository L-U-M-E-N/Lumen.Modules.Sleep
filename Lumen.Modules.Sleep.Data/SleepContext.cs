using Lumen.Modules.Sleep.Common.Models;

using Microsoft.EntityFrameworkCore;

namespace Lumen.Modules.Sleep.Data {
    public class SleepContext : DbContext {
        public const string SCHEMA_NAME = "Sleep";

        public SleepContext(DbContextOptions<SleepContext> options) : base(options) {
        }

        public DbSet<SleepPointInTime> Sleep { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema(SCHEMA_NAME);

            var SleepModelBuilder = modelBuilder.Entity<SleepPointInTime>();
            SleepModelBuilder.Property(x => x.Time)
                .HasColumnType("timestamp with time zone");

            SleepModelBuilder.Property(x => x.Value)
                .HasColumnType("integer");

            SleepModelBuilder.HasKey(x => x.Time);
        }
    }
}
