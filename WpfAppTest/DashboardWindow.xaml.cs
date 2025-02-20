using System.Windows;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Wpf;
using WpfOBDTest.Services;

namespace WpfOBDTest
{
    public partial class DashboardWindow : Window
    {
        private readonly CarDataModel _carData;
        private readonly FakeObdService _fakeObd;

        public DashboardWindow()
        {
            InitializeComponent();
            _carData = new CarDataModel();
            _fakeObd = new FakeObdService(_carData);
            DataContext = _carData;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }

        private void ShowInfo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_carData.GetStaticInfo(), "Информация о ТС", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
