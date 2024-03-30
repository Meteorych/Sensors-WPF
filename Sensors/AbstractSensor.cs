using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;
using Sensors_WPF__.NET_03._1_.Modes;
using Sensors_WPF__.NET_03._1_.Sensors.SensorsObservation;

namespace Sensors_WPF__.NET_03._1_.Sensors;

public abstract class AbstractSensor : INotifyPropertyChanged, IObservable<Measurement>
{
    protected IMode CurrentState;
    protected HashSet<IObserver<Measurement>> Observers = [];
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid SensorId { get; set; }

    public string SensorType { get; set; }
    public TimeSpan TimeInterval { get; set; }

    protected string CurrentStateNameValue;

    [NotMapped]
    public string CurrentStateName
    {
        get => CurrentStateNameValue;
        set
        {
            if (CurrentStateNameValue == value) return;
            CurrentStateNameValue = value;
            OnPropertyChanged(nameof(CurrentStateName));
        }
    }

    protected AbstractSensor()
    {
        CurrentState = new SleepMode();
        CurrentStateName = CurrentState.GetType().Name;
    }

    public virtual void Request(TextBox textBox)
    {
        CurrentState.DoWork(this, textBox, out var value);
        Notify(value);
    }

    /// <summary>
    /// Method for changing mode of the Sensor by scheme "Sleep" - "Calibration" - "Work" - "Sleep".
    /// </summary>
    public void ChangeMode()
    {
        CurrentState.ChangeMode(this);
        CurrentStateName = CurrentState.GetType().Name;
    }

    /// <summary>
    /// Changing mode to "Calibration".
    /// </summary>
    public void Calibrate()
    {
        if (CurrentStateName == "SleepMode")
        {
            CurrentState = new CalibrationMode();
            CurrentStateName = CurrentState.GetType().Name;
        }
    }

    /// <summary>
    /// Changing mode to "Sleep".
    /// </summary>
    public void Sleep()
    {
        if (CurrentStateName == "WorkMode")
        {
            CurrentState = new SleepMode();
            CurrentStateName = CurrentState.GetType().Name;
        }
    }

    /// <summary>
    /// Changing mode to "Work".
    /// </summary>
    public void Start()
    {
        if (CurrentStateName == "CalibrationMode")
        {
            CurrentState = new WorkMode();
            CurrentStateName = CurrentState.GetType().Name;
        }
    } 

    public void Notify(Measurement value)
    {
        foreach (var observer in Observers)
        {
            observer.OnNext(value);   
        }
    }

    /// <summary>
    /// Method that is called when sensor stops his measurement.
    /// </summary>
    public void LastMeasurementReceived()
    {
        foreach (var observer in Observers)
        {
            observer.OnCompleted();
        }
        Observers.Clear();
    }

    public IDisposable Subscribe(IObserver<Measurement> observer)
    {
        Observers.Add(observer);
        return new Unsubscriber(Observers, observer);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}