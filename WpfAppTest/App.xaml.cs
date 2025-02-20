using System;
using System.Collections.Generic;
using System.Configuration;
//using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfAppTest.Properties;

namespace WpfAppTest
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            string lang = WpfAppTest.Properties.Settings.Default.Language;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            base.OnStartup(e);
        }
    }
}
