namespace Sensors_WPF__.NET_03._1_.Sensors.SensorsObservation;

/// <summary>
/// CLass that is used to unsubscribe and dispose sensors.
/// </summary>
internal  sealed class Unsubscriber : IDisposable
{
    private readonly ISet<IObserver<Measurement>> _observers;
    private readonly IObserver<Measurement> _observer;

    internal Unsubscriber(
        ISet<IObserver<Measurement>> observers,
        IObserver<Measurement> observer) => (_observers, _observer) = (observers, observer);

    public void Dispose() => _observers.Remove(_observer);
}