using System.Windows.Controls;
using Sensors_WPF__.NET_03._1_.Sensors;
using Sensors_WPF__.NET_03._1_.Sensors.SensorsObservation;

namespace Sensors_WPF__.NET_03._1_.Modes;

public class WorkMode : IMode
{
    public void DoWork(AbstractSensor sensor, TextBox textBox, out Measurement value)
    {
        var randNumber = new Random();
        var measurementNumber = randNumber.Next();
        value = new Measurement(measurementNumber);
        textBox.Text += $"{measurementNumber} ";
    }

    public void ChangeMode(AbstractSensor sensor)
    {
        sensor.Sleep();
    }
}