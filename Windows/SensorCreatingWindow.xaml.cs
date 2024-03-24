using System;
using System.Collections.Generic;
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

namespace Sensors_WPF__.NET_03._1_.Windows
{
    /// <summary>
    /// Interaction logic for SensorCreatingWindow.xaml
    /// </summary>
    public partial class SensorCreatingWindow : Window
    {
        public SensorCreatingWindow()
        {
            InitializeComponent();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
