using System.ComponentModel;
using Marliazen.Software.Core.Interfaces;

namespace Marliazen.Software.Core
{
    public abstract class ViewModelBase : IViewModelBase
    {
        public abstract string Header { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}