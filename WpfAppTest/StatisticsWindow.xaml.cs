using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Windows;

namespace WpfOBDTest
{
    public partial class StatisticsWindow : Window
    {
        public SeriesCollection AvgFuelConsumptionChart { get; set; }
        public SeriesCollection AvgSpeedChart { get; set; }
        public SeriesCollection EngineHoursChart { get; set; }
        public SeriesCollection DistanceTraveledChart { get; set; }
        public SeriesCollection FuelUsedChart { get; set; }
        public SeriesCollection FuelCostChart { get; set; }

        public StatisticsWindow()
        {
            InitializeComponent();
            InitializeViewModel();
            LoadData();
            DrawGraph();
            ConfigureAxis();
        }

        private void InitializeViewModel()
        {
            AvgFuelConsumptionChart = new SeriesCollection();
            AvgSpeedChart = new SeriesCollection();
            EngineHoursChart = new SeriesCollection();
            DistanceTraveledChart = new SeriesCollection();
            FuelUsedChart = new SeriesCollection();
            FuelCostChart = new SeriesCollection();
        }

        // Метод для загрузки данных
        private void LoadData()
        {
            AddChartData(AvgFuelConsumptionChart);
            AddChartData(AvgSpeedChart);
            AddChartData(EngineHoursChart);
            AddChartData(DistanceTraveledChart);
            AddChartData(FuelUsedChart);
            AddChartData(FuelCostChart);
        }

        // Метод для добавления данных в графики
        private void AddChartData(SeriesCollection chart)
        {
            chart.Add(new LineSeries
            {
                Title = "Data Series",
                Values = new ChartValues<double> { 15, 30, 40, 20, 25, 35 }
            });
        }

        // Метод для настройки осей
        private void ConfigureAxis()
        {
            // Настроим ось X
            ChartControl.AxisX.Add(new Axis
            {
                Title = "Time",
                LabelsRotation = 15,
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = true
                }
            });

            // Настроим ось Y
            ChartControl.AxisY.Add(new Axis
            {
                Title = "Value",
                LabelFormatter = value => value.ToString("N")
            });
        }

        // Метод для отрисовки графиков +
        private void DrawGraph()
        {
            AvgFuelConsumptionChart[0].Values = new ChartValues<double> { 15, 30, 40, 20, 25, 35 };
            AvgSpeedChart[0].Values = new ChartValues<double> { 40, 60, 50, 45, 55, 50 };
            EngineHoursChart[0].Values = new ChartValues<double> { 5, 10, 15, 12, 8, 13 };
            DistanceTraveledChart[0].Values = new ChartValues<double> { 100, 200, 300, 400, 500, 600 };
            FuelUsedChart[0].Values = new ChartValues<double> { 30, 40, 35, 50, 45, 40 };
            FuelCostChart[0].Values = new ChartValues<double> { 20, 30, 25, 35, 40, 50 };
        }
    }
}
