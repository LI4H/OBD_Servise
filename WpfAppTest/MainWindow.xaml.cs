using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using WpfAppTest;
using WpfOBDTest.Services;

namespace WpfOBDTest
{
    public partial class MainWindow : Window
    {
        private TabControl _TabControl;
        private readonly CarDataModel _carData;
        private FakeObdService _fakeObdService;
        private bool _isDemoMode = false;
 

        public MainWindow()
        {
            InitializeComponent();
            _carData = new CarDataModel();
            DataContext = _carData;
            _fakeObdService = new FakeObdService(_carData); // Генерация данных ctrl z

            // Подписываемся на событие после инициализации интерфейса
            this.Loaded += (s, e) =>
            {
                _TabControl = (TabControl)NavigationPanel.FindName("TabControl");
                if (_TabControl != null)
                    _TabControl.SelectionChanged += TabControl_SelectionChanged;
            };

            ChangeLanguage("en");
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_TabControl.SelectedItem is TabItem selectedTab)
            {
                string tabName = selectedTab.Header.ToString();
                NavigationPanel.NavigateTo(tabName, this);
            }
        }

        public void ChangeLanguage(string languageCode)
        {
            try
            {
                var culture = new CultureInfo(languageCode);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
                var dict = new ResourceDictionary
                {
                    Source = new Uri($"pack://application:,,,/Resources/Strings.{languageCode}.xaml")
                };
                Resources.MergedDictionaries.Clear();
                Resources.MergedDictionaries.Add(dict);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки ресурсов: {ex.Message}", "Ошибка");
            }
        }

        private void DemoButton_Click(object sender, RoutedEventArgs e)
        {
            _isDemoMode = !_isDemoMode;
            if (_isDemoMode)
            {
                _fakeObdService.Start();
            }
            else
            {
                _fakeObdService.Stop();
            }
        }
    }
}
