using System;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;


namespace WpfOBDTest.Services

{
    public class FakeObdService
    {
        private readonly CarDataModel _carData;
        private readonly DispatcherTimer _timer;
        private readonly Random _random = new Random();

        public FakeObdService(CarDataModel carData)
        {
            _carData = carData;
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += UpdateFakeData;
            _timer.Start();
        }

        private void UpdateFakeData(object sender, EventArgs e)
        {
            _carData.Speed = _random.Next(0, 200);
            _carData.RPM = _random.Next(700, 6000);
            _carData.EngineTemp = _random.Next(80, 120);
            _carData.FuelLevel = _random.Next(0, 100);
        }
        public class ErrorCode
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }
    }
}
