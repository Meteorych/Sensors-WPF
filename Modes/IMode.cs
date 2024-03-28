using System.ComponentModel.DataAnnotations;
using Sensors_WPF__.NET_03._1_.Sensors;

namespace Sensors_WPF__.NET_03._1_.Modes
{
    public interface IMode
    {
        public void DoWork(AbstractSensor sensor);
        public void ChangeMode(AbstractSensor sensor);
    }
}
