using Microsoft.EntityFrameworkCore;
using SchedulerEF.Entities;
using TickerQ.EntityFrameworkCore.Configurations;

namespace SchedulerEF
{
    public class SchedulerContext : DbContext
    {
        public SchedulerContext() { }
        public SchedulerContext(DbContextOptions<SchedulerContext> options) : base(options) { }

        public DbSet<JobExceptions> JobExceptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TimeTickerConfigurations());
            modelBuilder.ApplyConfiguration(new CronTickerConfigurations());
            modelBuilder.ApplyConfiguration(new CronTickerOccurrenceConfigurations());

            modelBuilder.Entity<JobExceptions>(e =>
            {
                e.HasKey(u => u.Id);
            });
        }
    }
}
