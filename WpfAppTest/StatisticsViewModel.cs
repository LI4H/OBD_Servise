using LiveCharts;
using System.Collections.ObjectModel;
using System.ComponentModel;

public class StatisticsViewModel : INotifyPropertyChanged
{
    public ObservableCollection<ChartPoint> AvgFuelConsumptionChart { get; set; }
    public ObservableCollection<ChartPoint> AvgSpeedChart { get; set; }
    public ObservableCollection<ChartPoint> EngineHoursChart { get; set; }
    public ObservableCollection<ChartPoint> DistanceTraveledChart { get; set; }
    public ObservableCollection<ChartPoint> FuelUsedChart { get; set; }
    public ObservableCollection<ChartPoint> FuelCostChart { get; set; }

    public ObservableCollection<string> TimeLabels { get; set; }

    // Пример для одной из коллекций
    public StatisticsViewModel()
    {
        AvgFuelConsumptionChart = new ObservableCollection<ChartPoint>();
        AvgSpeedChart = new ObservableCollection<ChartPoint>();
        // Добавьте все остальные коллекции

        TimeLabels = new ObservableCollection<string>();

        // Пример для временных меток
        TimeLabels.Add("10:00");
        TimeLabels.Add("10:30");
        // и так далее
    }

    public event PropertyChangedEventHandler PropertyChanged;

    // Дополнительный код для обновления данных и уведомлений о изменениях
}
