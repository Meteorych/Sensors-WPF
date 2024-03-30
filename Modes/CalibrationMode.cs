using System.Windows.Controls;
using Sensors_WPF__.NET_03._1_.Sensors;
using Sensors_WPF__.NET_03._1_.Sensors.SensorsObservation;

namespace Sensors_WPF__.NET_03._1_.Modes;

public class CalibrationMode : IMode
{
    private int _calibrationNumber = 0;
    public void DoWork(AbstractSensor sensor, TextBox textBox, out Measurement value)
    {
        textBox.Text += $"{_calibrationNumber} ";
        value = new Measurement(_calibrationNumber);
        _calibrationNumber += 1;
    }

    public void ChangeMode(AbstractSensor sensor)
    {
        sensor.Start();
    }
}