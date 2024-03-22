using System.Collections.ObjectModel;
using System.Windows;
using Sensors_WPF__.NET_03._1_.Sensors;


namespace Sensors_WPF__.NET_03._1_.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SensorsDbContext _dbContext;

        public MainWindow()
        {
            InitializeComponent();
            _dbContext = new SensorsDbContext();
            DataContext = _dbContext;
        }


        private void CreateSensorButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}