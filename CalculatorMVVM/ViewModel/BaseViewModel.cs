using System.ComponentModel;

namespace CalculatorMVVM
{
    /// <summary>
    /// Базовый класс, реализующий INotifyPropertyChanged
    /// </summary>
    class BaseViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
