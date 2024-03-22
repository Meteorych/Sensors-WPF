using System.ComponentModel.DataAnnotations;
using Sensors_WPF__.NET_03._1_.Modes;

namespace Sensors_WPF__.NET_03._1_.Sensors
{
    public abstract class AbstractSensor
    {
        [Key]
        public int SensorId { get; private set; }
        public virtual AbstractMode AbstractMode { get; set; }
        public string SensorType { get; private set; }
        public abstract void Request();

    }
}
