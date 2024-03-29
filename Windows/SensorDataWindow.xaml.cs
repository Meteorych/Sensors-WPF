using Sensors_WPF__.NET_03._1_.Sensors;
using System.Windows;
using System.Windows.Controls;

namespace Sensors_WPF__.NET_03._1_.Windows
{
    /// <summary>
    /// Interaction logic for SensorWindow.xaml
    /// </summary>
    public partial class SensorDataWindow : Window
    {
        private readonly Sensor _sensor;
        public SensorDataWindow(Sensor sensor)
        {
            _sensor = sensor;
            InitializeComponent();
           
        }
    }
}
