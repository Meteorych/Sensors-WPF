using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Sensors_WPF__.NET_03._1_.Sensors;
using Sensors_WPF__.NET_03._1_.ViewModels;


namespace Sensors_WPF__.NET_03._1_.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;  
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }


        private void CreateSensorButton_Click(object sender, RoutedEventArgs e)
        {
            var createSensorWindow = new SensorCreatingWindow(_viewModel);
            createSensorWindow.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button) _viewModel.DeleteSensor(button.DataContext as Sensor ?? throw new InvalidOperationException());
        }
    }
}