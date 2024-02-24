using Sensors_WPF__.NET_03._1_.Sensors;

namespace Sensors_WPF__.NET_03._1_.Modes
{
    public abstract class AbstractMode
    {
        public abstract void DoWork(AbstractSensor sensor);
    }
}
