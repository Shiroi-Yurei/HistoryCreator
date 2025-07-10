using System.ComponentModel;

namespace Marliazen.Software.Core.Interfaces
{
    public interface IViewModelBase : INotifyPropertyChanged
    {
        public string Header { get; }
    }
}
