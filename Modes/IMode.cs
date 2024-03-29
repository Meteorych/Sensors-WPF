using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;
using Sensors_WPF__.NET_03._1_.Sensors;

namespace Sensors_WPF__.NET_03._1_.Modes
{
    public interface IMode
    {
        public void DoWork(AbstractSensor sensor, TextBox textBox);
        public void ChangeMode(AbstractSensor sensor);
    }
}
