using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfOBDTest.Controls
{
    public partial class CustomTitleBar : UserControl
    {
        public CustomTitleBar()
        {
            InitializeComponent();
        }

        private Window GetParentWindow() => Window.GetWindow(this);

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = GetParentWindow();
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void MaximizeWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = GetParentWindow();
            if (window != null)
            {
                window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = GetParentWindow();
            if (window != null)
            {
                window.Close();
            }
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var window = GetParentWindow();
            if (window != null && e.LeftButton == MouseButtonState.Pressed)
            {
                window.DragMove();
            }
        }
    }
}
