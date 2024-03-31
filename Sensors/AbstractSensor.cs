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
    /// <summary>
    /// Name of current mode.
    /// </summary>
    protected string CurrentModeNameValue;
    /// <summary>
    /// Current mode of sensor.
    /// </summary>
    protected IMode CurrentMode;
    /// <summary>
    /// Sensor's observers.
    /// </summary>
    protected HashSet<IObserver<Measurement>> Observers = [];

    [Key]
    public Guid SensorId { get; init; }
    public string SensorType { get; set; }
    public TimeSpan TimeInterval { get; set; }

    [NotMapped]
    public string CurrentStateName
    {
        get => CurrentModeNameValue;
        set
        {
            if (CurrentModeNameValue == value) return;
            CurrentModeNameValue = value;
            OnPropertyChanged(nameof(CurrentStateName));
        }
    }

    protected AbstractSensor()
    {
        SensorId = SensorsIDGenerator.GetInstance().GenerateId();
        CurrentMode = new SleepMode();
        CurrentStateName = CurrentMode.GetType().Name;
    }

    /// <summary>
    /// Method for requesting sensor's data and writing it to the provided TextBox.
    /// </summary>
    /// <param name="textBox">WPF TextBox for writing provided data.</param>
    public virtual void Request(TextBox textBox)
    {
        CurrentMode.DoWork(this, textBox, out var value);
        Notify(value);
    }

    /// <summary>
    /// Method for changing mode of the Sensor by scheme "Sleep" - "Calibration" - "Work" - "Sleep".
    /// </summary>
    public void ChangeMode()
    {
        CurrentMode.ChangeMode(this);
        CurrentStateName = CurrentMode.GetType().Name;
    }

    /// <summary>
    /// Changing mode to "Calibration".
    /// </summary>
    public void Calibrate()
    {
        if (CurrentStateName == "SleepMode")
        {
            CurrentMode = new CalibrationMode();
            CurrentStateName = CurrentMode.GetType().Name;
        }
    }

    /// <summary>
    /// Changing mode to "Sleep".
    /// </summary>
    public void Sleep()
    {
        if (CurrentStateName == "WorkMode")
        {
            CurrentMode = new SleepMode();
            CurrentStateName = CurrentMode.GetType().Name;
        }
    }

    /// <summary>
    /// Changing mode to "Work".
    /// </summary>
    public void Start()
    {
        if (CurrentStateName == "CalibrationMode")
        {
            CurrentMode = new WorkMode();
            CurrentStateName = CurrentMode.GetType().Name;
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