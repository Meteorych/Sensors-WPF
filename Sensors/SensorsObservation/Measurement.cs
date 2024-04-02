namespace Sensors_WPF__.NET_03._1_.Sensors.SensorsObservation;

/// <summary>
/// Class for storing value from sensor.
/// </summary>
/// <param name="measurementNum">Sensor's value.</param>
public readonly struct Measurement(int measurementNum)
{
    public int MeasurementNum => measurementNum;
};