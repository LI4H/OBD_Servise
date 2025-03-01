using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfOBDTest.Controls
{
    public partial class NavigationPanel : UserControl
    {
        public NavigationPanel()
        {
            InitializeComponent();

            // Найдём TabControl и вручную подпишемся на SelectionChanged
            Loaded += (s, e) =>
            {
                var tabControl = (TabControl)FindName("TabControl");
                if (tabControl != null)
                    tabControl.SelectionChanged += TabControl_SelectionChanged;
            };
        }

        public void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is TabControl tabControl && tabControl.SelectedItem is TabItem selectedTab)
            {
                string tabName = selectedTab.Header.ToString();
                Window currentWindow = Window.GetWindow(this);
                NavigateTo(tabName, currentWindow);
            }
        }

        public void NavigateTo(string tabName, Window currentWindow)
        {
            if (currentWindow == null) return;

            switch (tabName)
            {
                case "Главная":
                    ShowWindow<MainWindow>(currentWindow);
                    break;
                case "Динамика":
                    ShowWindow<DashboardWindow>(currentWindow);
                    break;
                case "Ошибки":
                    ShowWindow<ErrorsWindow>(currentWindow);
                    break;
                case "Статистика":
                    ShowWindow<StatisticsWindow>(currentWindow);
                    break;
                case "Настройки":
                    ShowWindow<SettingsWindow>(currentWindow);
                    break;
            }
        }

        private void ShowWindow<T>(Window currentWindow) where T : Window, new()
        {
            var existingWindow = Application.Current.Windows.OfType<T>().FirstOrDefault();
            if (existingWindow == null)
            {
                new T().Show();
            }
            else
            {
                existingWindow.Visibility = Visibility.Visible;
                existingWindow.Activate();
            }
            currentWindow.Close();
        }
    }
}
