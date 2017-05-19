using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmartBankDesktop.Controller
{
    internal class AbstractController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}