using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;
using Sensors_WPF__.NET_03._1_.Modes;

namespace Sensors_WPF__.NET_03._1_.Sensors;

public abstract class AbstractSensor : INotifyPropertyChanged
{
    protected IMode CurrentState;

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

    public virtual void Request(TextBox textBox)
    {
        CurrentState.DoWork(this, textBox);
    }
    protected AbstractSensor()
    {
        CurrentState = new SleepMode();
        CurrentStateName = CurrentState.GetType().Name;
    }

    public void ChangeMode()
    {
        CurrentState.ChangeMode(this);
        CurrentStateName = CurrentState.GetType().Name;
    }

    public void Calibrate() => CurrentState = new CalibrationMode();
    public void Sleep() => CurrentState = new SleepMode();
    public void Start() => CurrentState = new WorkMode();

    // Other methods remain unchanged

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}