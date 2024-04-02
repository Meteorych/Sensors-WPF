using Sensors_WPF__.NET_03._1_.Sensors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Sensors_WPF__.NET_03._1_.Windows;

/// <summary>
/// Interaction logic for SensorWindow.xaml
/// </summary>
public partial class SensorDataWindow : Window
{
    private DispatcherTimer _timer;
    private readonly Sensor _sensor;

    public SensorDataWindow(Sensor sensor)
    {
        _sensor = sensor;
        InitializeComponent();
        Loaded += SensorDataWindow_Loaded;
        Closed += SensorDataWindow_Closed;
    }

    private void SensorDataWindow_Loaded(object sender, RoutedEventArgs e)
    {
        _timer = new DispatcherTimer
        {
            Interval = _sensor.CurrentModeName == "WorkMode" ? _sensor.TimeInterval : TimeSpan.FromSeconds(1)
        };
        _timer.Tick += SensorAction;
        _timer.Start();
    }

    private void SensorDataWindow_Closed(object? sender, EventArgs e)
    {
        _sensor.LastMeasurementReceived();
    }

    private void SensorAction(object? sender, EventArgs e)
    {
        _sensor.Request(SensorData);
    }
}