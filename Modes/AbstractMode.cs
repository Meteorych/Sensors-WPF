using System.ComponentModel.DataAnnotations;
using Sensors_WPF__.NET_03._1_.Sensors;

namespace Sensors_WPF__.NET_03._1_.Modes
{
    public abstract class AbstractMode
    {
        [Key]
        public int Id { get; set; }
        public virtual string Name { get; }
        public abstract void DoWork(AbstractSensor sensor);
    }
}
