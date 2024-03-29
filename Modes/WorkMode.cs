using System.Windows.Controls;
using Sensors_WPF__.NET_03._1_.Sensors;

namespace Sensors_WPF__.NET_03._1_.Modes
{
    public class WorkMode : IMode
    {
        public void DoWork(AbstractSensor sensor, TextBox textBox)
        {
            var randNumber = new Random();
            textBox.Text += $"{randNumber.Next()} ";
        }

        public void ChangeMode(AbstractSensor sensor)
        {
            sensor.Sleep();
        }
    }
}
