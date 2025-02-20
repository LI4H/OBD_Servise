using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using WpfAppTest.Properties;

namespace WpfOBDTest
{
    public partial class SettingsWindow : Window
    {
        private bool _isInitialized = false;

        public SettingsWindow()
        {
            InitializeComponent();
            InitializeLanguage();
            _isInitialized = true;
        }

        private void InitializeLanguage()
        {
            string currentLanguage = Settings.Default.Language;
            foreach (ListBoxItem item in LanguageListBox.Items)
            {
                if (item.Tag.ToString() == currentLanguage)
                {
                    LanguageListBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void ChangeLanguage(object sender, SelectionChangedEventArgs e)
        {
            if (!_isInitialized) return; // Игнорируем первый вызов

            string selectedLanguage = (LanguageListBox.SelectedItem as ListBoxItem)?.Tag.ToString();
            if (selectedLanguage != null)
            {
                Settings.Default.Language = selectedLanguage;
                Settings.Default.Save();
                ApplyLanguage(selectedLanguage);
            }
        }

        private void ApplyLanguage(string languageCode)
        {
            // Изменить культуру потока
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageCode);

            // Перезагрузить ресурсы для выбранного языка
            var dict = new ResourceDictionary();
            if (languageCode == "ru")
            {
                dict.Source = new Uri("pack://application:,,,/WpfAppTest;component/Resources/Strings.ru.xaml");
            }
            else if (languageCode == "en")
            {
                dict.Source = new Uri("pack://application:,,,/WpfAppTest;component/Resources/Strings.en.xaml");
            }

            // Очистить старые ресурсы и добавить новые
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(dict);

           // MessageBox.Show("Язык изменён, перезапустите приложение", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }



        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
