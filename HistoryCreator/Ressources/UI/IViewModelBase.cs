using System.ComponentModel;

namespace HistoryCreator.Ressources.UI.Interfaces
{
    public interface IViewModelBase : INotifyPropertyChanged
    {
        public string Header { get; }
    }
}
