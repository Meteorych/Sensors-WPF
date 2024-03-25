using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sensors_WPF__.NET_03._1_.Modes;

namespace Sensors_WPF__.NET_03._1_.Sensors
{
    public abstract class AbstractSensor
    {
        private IMode _currentState;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SensorId { get; set; }
        
        public string SensorType { get; set; }
        public TimeSpan TimeInterval { get; set; }

        [NotMapped]
        public string CurrentState => _currentState.GetType().ToString().Split(".")[^1];

        protected AbstractSensor()
        {
            _currentState = new SleepMode();
        }

        public void SetCurrentState(IMode mode)
        {
            _currentState = mode;
        }
        public abstract void Request();

    }
}
