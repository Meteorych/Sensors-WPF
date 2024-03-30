namespace Sensors_WPF__.NET_03._1_.Sensors.SensorsObservation;

class SensorObserver : IObserver<Measurement>
{
    public void OnNext(Measurement value)
    {
    }
    public void OnError(Exception ex) { }
    public void OnCompleted()
    {
    }
}