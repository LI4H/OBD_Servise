using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfOBDTest
{
    public class CarDataModel : INotifyPropertyChanged
    {
        private int _speed;
        private int _rpm;
        private int _engineTemp;
        private int _fuelLevel;

        public int Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                OnPropertyChanged();
                SpeedChart.Add(value);
                if (SpeedChart.Count > 20) SpeedChart.RemoveAt(0); // Ограничение данных в графике
            }
        }

        public int RPM
        {
            get => _rpm;
            set
            {
                _rpm = value;
                OnPropertyChanged();
                RpmChart.Add(value);
                if (RpmChart.Count > 20) RpmChart.RemoveAt(0);
            }
        }

        public int EngineTemp
        {
            get => _engineTemp;
            set
            {
                _engineTemp = value;
                OnPropertyChanged();
                EngineTempChart.Add(value);
                if (EngineTempChart.Count > 20) EngineTempChart.RemoveAt(0);
            }
        }

        public int FuelLevel
        {
            get => _fuelLevel;
            set
            {
                _fuelLevel = value;
                OnPropertyChanged();
                FuelLevelChart.Add(value);
                if (FuelLevelChart.Count > 20) FuelLevelChart.RemoveAt(0);
            }
        }

        public string GetStaticInfo()
        {
            return "Марка: Toyota\nМодель: Camry\nГод выпуска: 2022\nОбъем двигателя: 2.5L";
        }

        public ChartValues<int> SpeedChart { get; set; } = new ChartValues<int>();
        public ChartValues<int> RpmChart { get; set; } = new ChartValues<int>();
        public ChartValues<int> EngineTempChart { get; set; } = new ChartValues<int>();
        public ChartValues<int> FuelLevelChart { get; set; } = new ChartValues<int>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
