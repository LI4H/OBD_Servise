using System.Windows;
using WpfAppTest;
using System.Globalization;
using System.Threading;
using System;

namespace WpfOBDTest
{
    public partial class MainWindow : Window
    {
        private readonly CarDataModel _carData;

        public MainWindow()
        {
            InitializeComponent();
            _carData = new CarDataModel();
            DataContext = _carData;
            new Services.FakeObdService(_carData); // Генерация данных
            ChangeLanguage("en");
        }

        private void OpenDashboard(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            DashboardWindow dashboard = new DashboardWindow();
            dashboard.Show();
        }

        private void OpenErrors(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            ErrorsWindow errors = new ErrorsWindow();
            errors.Show();
        }

        private void ShowInfo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_carData.GetStaticInfo(), "Статическая информация");
        }

        private void OpenSettings(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            SettingsWindow settings = new SettingsWindow();
            settings.Show();
        }

        private void OpenStatistics(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            StatisticsWindow statistics = new StatisticsWindow();
            statistics.Show();
        }

        public void ChangeLanguage(string languageCode)
        {
            try
            {
                var culture = new CultureInfo(languageCode);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;

                var dict = new ResourceDictionary();

                if (languageCode == "ru")
                    dict.Source = new Uri("pack://application:,,,/Resources/Strings.ru.xaml");
                else if (languageCode == "en")
                    dict.Source = new Uri("pack://application:,,,/Resources/Strings.en.xaml");

                this.Resources.MergedDictionaries.Clear();
                this.Resources.MergedDictionaries.Add(dict);
            }
            catch (UriFormatException ex)
            {
                // Логирование или отображение ошибки
                MessageBox.Show($"Ошибка загрузки ресурсов: {ex.Message}", "Ошибка");
            }
            catch (Exception ex)
            {
                // Общая обработка ошибок
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка");
            }
        }

    }
}
