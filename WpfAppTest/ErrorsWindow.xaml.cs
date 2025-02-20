using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace WpfOBDTest
{
    public partial class ErrorsWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<ErrorCode> _allErrors;
        private ObservableCollection<ErrorCode> _filteredErrors;
        private ErrorCode _selectedError;

        private bool _isResetEnabled;
        public bool IsResetEnabled
        {
            get => _isResetEnabled;
            set
            {
                _isResetEnabled = value;
                OnPropertyChanged(nameof(IsResetEnabled));
            }
        }

        public ErrorsWindow()
        {
            InitializeComponent();
            LoadErrors();
            DataContext = this; // Привязка данных для текущего окна
        }

        private void LoadErrors()
        {
            _allErrors = new ObservableCollection<ErrorCode>
            {
                new ErrorCode { Code = "P0301", Description = "Пропуски зажигания в цилиндре 1" },
                new ErrorCode { Code = "P0420", Description = "Низкая эффективность катализатора" },
                new ErrorCode { Code = "P0171", Description = "Обедненная топливная смесь" },
                new ErrorCode { Code = "P0500", Description = "Неисправность датчика скорости" },
                new ErrorCode { Code = "P0455", Description = "Обнаружена крупная утечка в системе испарения топлива" }
            };

            _filteredErrors = new ObservableCollection<ErrorCode>(_allErrors);
            ErrorList.ItemsSource = _filteredErrors;
        }

        private void SearchErrors(object sender, TextChangedEventArgs e)
        {
            string query = SearchBox.Text.ToLower();
            _filteredErrors.Clear();

            foreach (var error in _allErrors.Where(err => err.Code.ToLower().Contains(query) || err.Description.ToLower().Contains(query)))
            {
                _filteredErrors.Add(error);
            }
        }

        // Обработчик выбора ошибки
        private void OnErrorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedError = ErrorList.SelectedItem as ErrorCode;
            IsResetEnabled = _selectedError != null; // Обновляем состояние кнопки
        }

        // Обработчик сброса выбранной ошибки
        private void ResetError(object sender, RoutedEventArgs e)
        {
            if (_selectedError != null)
            {
                _allErrors.Remove(_selectedError);  // Удаляем ошибку из списка
                _filteredErrors.Remove(_selectedError);  // Обновляем отображение
                _selectedError = null;  // Сбрасываем выбранную ошибку
                IsResetEnabled = false; // Отключаем кнопку сброса
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow main = new MainWindow();
            main.Show();
        }

        // Реализация INotifyPropertyChanged для обновления UI
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        // Обработчик фокуса на поле поиска
        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchPlaceholder.Visibility = Visibility.Collapsed; // Скрываем подсказку при фокусе
        }

        // Обработчик потери фокуса с поля поиска
        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text))
            {
                SearchPlaceholder.Visibility = Visibility.Visible; // Показываем подсказку, если поле пустое
            }
        }
    }

    public class ErrorCode
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public override string ToString() => $"{Code}: {Description}";
    }
}
