using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sensors_WPF__.NET_03._1_.Modes;

namespace Sensors_WPF__.NET_03._1_.Sensors
{
    public abstract class AbstractSensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SensorId { get; set; }

        [NotMapped]
        public virtual IMode CurrentState { get; set; }

        public string SensorType { get; set; }
        public abstract void Request();

    }
}
