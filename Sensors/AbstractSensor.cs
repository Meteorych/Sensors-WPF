using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sensors_WPF__.NET_03._1_.Modes;

namespace Sensors_WPF__.NET_03._1_.Sensors;

public abstract class AbstractSensor : INotifyPropertyChanged
{
    private IMode _currentState;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid SensorId { get; set; }

    public string SensorType { get; set; }
    public TimeSpan TimeInterval { get; set; }

    private string _currentStateName;
    [NotMapped]
    public string CurrentStateName
    {
        get => _currentStateName;
        set
        {
            if (_currentStateName != value)
            {
                _currentStateName = value;
                OnPropertyChanged(nameof(CurrentStateName));
            }
        }
    }

    protected AbstractSensor()
    {
        _currentState = new SleepMode();
        CurrentStateName = _currentState.GetType().Name;
    }

    public void ChangeMode()
    {
        _currentState.ChangeMode(this);
        CurrentStateName = _currentState.GetType().Name;
    }

    public void Calibrate() => _currentState = new CalibrationMode();
    public void Sleep() => _currentState = new SleepMode();
    public void Start() => _currentState = new WorkMode();

    // Other methods remain unchanged

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public abstract void Request();
}