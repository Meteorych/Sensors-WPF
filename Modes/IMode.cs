using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;
using Sensors_WPF__.NET_03._1_.Sensors;
using Sensors_WPF__.NET_03._1_.Sensors.SensorsObservation;

namespace Sensors_WPF__.NET_03._1_.Modes;

public interface IMode
{
    /// <summary>
    /// Method that starts work of sensor in certain mode.
    /// </summary>
    /// <param name="sensor">Sensor that have certain mode and whose values are gotten by calling this method.</param>
    /// <param name="value">Value from sensor.</param>
    public void DoWork(AbstractSensor sensor, out Measurement value);
    /// <summary>
    /// Method that changing mode of sensor in cycle "Sleep" - "Calibration" - "Work" - "Sleep".
    /// </summary>
    /// <param name="sensor"></param>
    public void ChangeMode(AbstractSensor sensor);
}