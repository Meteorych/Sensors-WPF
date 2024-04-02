using System.Windows.Controls;
using Sensors_WPF__.NET_03._1_.Sensors;
using Sensors_WPF__.NET_03._1_.Sensors.SensorsObservation;

namespace Sensors_WPF__.NET_03._1_.Modes;

public class CalibrationMode : IMode
{
    /// <summary>
    /// Value that is filled into textBox in this mode.
    /// </summary>
    private int _calibrationNumber;
    
    /// <summary>
    /// Do work for sensor in calibration mode. 
    /// </summary>
    /// <param name="sensor">Sensor that have calibration mode enabled.</param>
    /// <param name="value"></param>
    public void DoWork(AbstractSensor sensor, out Measurement value)
    {
        value = new Measurement(_calibrationNumber);
        _calibrationNumber += 1;
    }

    public void ChangeMode(AbstractSensor sensor)
    {
        sensor.Start();
    }
}