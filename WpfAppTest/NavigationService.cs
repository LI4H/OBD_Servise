//using System;
//using System.Linq;
//using System.Windows;

//namespace WpfOBDTest.Services
//{
//    public static class NavigationService
//    {
//        public static void NavigateTo(string tabName, Window currentWindow)
//        {
//            switch (tabName)
//            {
//                case "Главная":
//                    ShowMainWindow(currentWindow);
//                    break;
//                case "Динамика":
//                    ShowWindow<DashboardWindow>(currentWindow);
//                    break;
//                case "Ошибки":
//                    ShowWindow<ErrorsWindow>(currentWindow);
//                    break;
//                case "Статистика":
//                    ShowWindow<StatisticsWindow>(currentWindow);
//                    break;
//                case "Настройки":
//                    ShowSettingsWindow(currentWindow);
//                    break;
//            }
//        }

//        private static void ShowMainWindow(Window currentWindow)
//        {
//            //var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
//            //if (mainWindow == null)
//            //{
//            //    mainWindow = new MainWindow
//            //    {
//            //        WindowStartupLocation = WindowStartupLocation.CenterScreen // Устанавливаем положение по центру
//            //    };
//            //    mainWindow.Show();
//            //}
//            //else
//            //{
//            //    mainWindow.Visibility = Visibility.Visible;
//            //    mainWindow.Activate(); // Фокусируем окно
//            //}
//            //currentWindow.Close();
//        }

//        private static void ShowSettingsWindow(Window currentWindow)
//        {
//            var settingsWindow = Application.Current.Windows.OfType<SettingsWindow>().FirstOrDefault();
//            if (settingsWindow == null)
//            {
//                settingsWindow = new SettingsWindow();
//                settingsWindow.Show();
//            }
//            else
//            {
//                settingsWindow.Visibility = Visibility.Visible;
//                settingsWindow.Activate();
//            }
//            currentWindow.Close();
//        }

//        private static void ShowWindow<T>(Window currentWindow) where T : Window, new()
//        {
//            var existingWindow = Application.Current.Windows.OfType<T>().FirstOrDefault();
//            if (existingWindow == null)
//            {
//                new T().Show();
//            }
//            else
//            {
//                existingWindow.Visibility = Visibility.Visible;
//                existingWindow.Activate();
//            }
//            currentWindow.Close();
//        }
//    }
//}