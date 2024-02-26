using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Sensors_WPF__.NET_03._1_.Modes;

namespace Sensors_WPF__.NET_03._1_.Sensors
{
    public abstract class AbstractSensor
    {
        public AbstractMode Mode { get; set; }
        public Guid SensorId { get; private set; }
        public string SensorType { get; private set; }
        public abstract void Request();
    }
}
