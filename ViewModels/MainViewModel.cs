using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Sensors_WPF__.NET_03._1_.Sensors;

namespace Sensors_WPF__.NET_03._1_.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Sensor> Sensors { get; set; }
    private readonly SensorsDbContext _dbContext;
    public MainViewModel()
    {
        Sensors = new ObservableCollection<Sensor>();
        _dbContext = new SensorsDbContext();
        var sensorsFromDb = _dbContext.Sensors.ToList();
        foreach (var sensor in sensorsFromDb)
        {
            Sensors.Add(sensor);
        }
    }

    public void AddSensor(Sensor newSensor)
    {
        Sensors.Add(newSensor);
        _dbContext.Sensors.Add(newSensor);
        _dbContext.SaveChanges();
    }

    public void DeleteSensor(Sensor sensorToRemove)
    {
        Sensors.Remove(sensorToRemove);
        _dbContext.Sensors.Remove(sensorToRemove);
        _dbContext.SaveChanges();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}