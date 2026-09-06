using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lumen.Modules.Sleep.Data {
    public class SleepDbContextFactory : IDesignTimeDbContextFactory<SleepContext> {
        public SleepContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<SleepContext>();
            optionsBuilder.UseNpgsql();

            return new SleepContext(optionsBuilder.Options);
        }
    }
}
