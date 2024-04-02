using System.Windows.Controls;
using Sensors_WPF__.NET_03._1_.Sensors;
using Sensors_WPF__.NET_03._1_.Sensors.SensorsObservation;

namespace Sensors_WPF__.NET_03._1_.Modes;

public class SleepMode : IMode
{
    public void DoWork(AbstractSensor sensor, out Measurement value)
    {
        value = new Measurement(0);
    }

    public void ChangeMode(AbstractSensor sensor)
    {
        sensor.Calibrate();
    }
}