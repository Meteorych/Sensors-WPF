using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Sensors_WPF__.NET_03._1_.Sensors;

namespace Sensors_WPF__.NET_03._1_.Windows
{
    /// <summary>
    /// Interaction logic for SensorCreatingWindow.xaml
    /// </summary>
    public partial class SensorCreatingWindow : Window
    {
        private readonly SensorsDbContext _dbContext;
        public SensorCreatingWindow(SensorsDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SensorType.Text))
            {
                MessageBox.Show("Enter the sensor type", "Sensor type is wrong");
            }

            if (!int.TryParse(Interval.Text, out var intervalInt))
            {
                MessageBox.Show("Provide working timespan interval", "Interval value is wrong");
            }

            _dbContext.Add(new Sensor(){SensorType = SensorType.Text, TimeInterval = TimeSpan.FromSeconds(intervalInt)});
        }

        
    }
}
