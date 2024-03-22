using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sensors_WPF__.NET_03._1_.Sensors;

namespace Sensors_WPF__.NET_03._1_.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Sensor> Sensors { get; set; }

        public MainViewModel()
        {
            Sensors = new ObservableCollection<Sensor>();
            using var dbContext = new SensorsDbContext();
            var sensorsFromDb = dbContext.Sensors.ToList();
            foreach (var sensor in sensorsFromDb)
            {
                Sensors.Add(sensor);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}