using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using WpfAppTest.Properties;
using WpfOBDTest.Services;

namespace WpfOBDTest
{
    public partial class SettingsWindow : Window
    {
        private string _previousTab = "";
        private readonly CarDataModel _carData;
        private readonly FakeObdService _fakeObd;
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

        private void SettingsTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (SettingsTabControl.SelectedItem is TabItem selectedTab)
            //{
            //    string currentTab = selectedTab.Header.ToString();

            //    if (currentTab == _previousTab) return;
            //    _previousTab = currentTab;
            //    NavigationPanel.NavigateTo(currentTab, this);
            //}
        }

        private void ChangeLanguage(object sender, SelectionChangedEventArgs e)
        {
            if (!_isInitialized) return;
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
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageCode);
            var dict = new ResourceDictionary();
            dict.Source = new Uri($"pack://application:,,,/WpfAppTest;component/Resources/Strings.{languageCode}.xaml");
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(dict);
        }


    }
}
