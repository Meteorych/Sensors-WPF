using System.IO;
using Microsoft.EntityFrameworkCore;
using Sensors_WPF__.NET_03._1_.Modes;

namespace Sensors_WPF__.NET_03._1_.Sensors
{
    public class SensorsDbContext : DbContext
    {
        public DbSet<Sensor> Sensors { get; set; }

        public DbSet<AbstractMode> Modes { get; set; }

        public string DbPath { get; set; }

        public SensorsDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SleepMode>();
            modelBuilder.Entity<WorkMode>();
            modelBuilder.Entity<CalibrationMode>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
