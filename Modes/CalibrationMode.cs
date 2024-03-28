using Sensors_WPF__.NET_03._1_.Sensors;

namespace Sensors_WPF__.NET_03._1_.Modes
{
    class CalibrationMode : IMode
    {

        public CalibrationMode()
        {

        }
        public void DoWork(AbstractSensor sensor)
        {

        }

        public void ChangeMode(AbstractSensor sensor)
        {
            sensor.Start();
        }
    }
}
