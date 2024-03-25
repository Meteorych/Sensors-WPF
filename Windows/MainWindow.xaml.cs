using System.Collections.ObjectModel;
using System.Windows;
using Sensors_WPF__.NET_03._1_.Sensors;
using Sensors_WPF__.NET_03._1_.ViewModels;


namespace Sensors_WPF__.NET_03._1_.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }


        private void CreateSensorButton_Click(object sender, RoutedEventArgs e)
        {
            var createSensorWindow = new SensorCreatingWindow(new SensorsDbContext());
            createSensorWindow.Show();
        }

    }
}