using Microsoft.EntityFrameworkCore;
using Sensors_WPF__.NET_03._1_.Modes;

namespace Sensors_WPF__.NET_03._1_.Sensors
{
    public class SensorsDbContext : DbContext
    {
        public DbSet<Sensor> Sensors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=sensorsDb;Integrated Security=True");
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensor>().HasData(new[]
            {
                new Sensor {SensorId = 1, SensorType = "Sensor №1" },
                new Sensor {SensorId = 2, SensorType = "Sensor №2" },
                new Sensor {SensorId = 3, SensorType = "Sensor №3"}
            }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
