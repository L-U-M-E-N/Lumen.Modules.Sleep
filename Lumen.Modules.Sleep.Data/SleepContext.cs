using Lumen.Modules.Sleep.Common.Models;

using Microsoft.EntityFrameworkCore;

namespace Lumen.Modules.Sleep.Data {
    public class SleepContext : DbContext {
        public const string SCHEMA_NAME = "Sleep";

        public SleepContext(DbContextOptions<SleepContext> options) : base(options) {
        }

        public DbSet<SleepEntry> Sleep { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema(SCHEMA_NAME);

            var SleepModelBuilder = modelBuilder.Entity<SleepEntry>();
            SleepModelBuilder.Property(x => x.Start)
                .HasColumnType("timestamp with time zone");

            SleepModelBuilder.Property(x => x.End)
                .HasColumnType("timestamp with time zone");

            SleepModelBuilder.HasKey(x => new { x.Start, x.End });
            SleepModelBuilder.HasIndex(x => new { x.Start }).IsUnique();
        }
    }
}
