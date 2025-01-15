using HistoryCreator.Ressources.UI.Interfaces;
using System.ComponentModel;

namespace HistoryCreator.Ressources.UI
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
