using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors_WPF__.NET_03._1_.Sensors
{
    class SensorsIDGenerator
    {
        private static SensorsIDGenerator? _instance;

        private SensorsIDGenerator(){}

        public Guid GenerateId()
        {
            return Guid.NewGuid();
        }

        public static SensorsIDGenerator GetInstance()
        {
            return _instance ??= new SensorsIDGenerator();
        }
    }
}
