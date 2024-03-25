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
            modelBuilder.Entity<Sensor>().HasData([
                    new Sensor {SensorId = Guid.NewGuid(), SensorType = "Sensor №1", TimeInterval = new TimeSpan(0, 0, 5)},
                new Sensor {SensorId = Guid.NewGuid(), SensorType = "Sensor №2", TimeInterval = new TimeSpan(0, 0, 2) },
                new Sensor {SensorId = Guid.NewGuid(), SensorType = "Sensor №3", TimeInterval = new TimeSpan(0, 0, 4)}
                ]
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
