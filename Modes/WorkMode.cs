﻿using Sensors_WPF__.NET_03._1_.Sensors;

namespace Sensors_WPF__.NET_03._1_.Modes
{
    class WorkMode : IMode
    {

        public WorkMode()
        {

        }
        public void DoWork(AbstractSensor sensor)
        {
             
        }

        public void ChangeState(AbstractSensor sensor)
        {
            sensor.Sleep();
        }
    }
}
