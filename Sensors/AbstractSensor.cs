using Sensors_WPF__.NET_03._1_.Modes;

namespace Sensors_WPF__.NET_03._1_.Sensors
{
    public abstract class AbstractSensor
    {
        public IMode Mode { get; set; }
        public Guid SensorId { get; private set; }
        public string SensorType { get; private set; }
        public abstract void Request();

    }
}
