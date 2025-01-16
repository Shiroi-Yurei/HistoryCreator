using HistoryCreator.Ressources.UI.Layout.Interfaces;
using System.Collections.ObjectModel;

namespace HistoryCreator.Ressources.UI.Manager.View.Interfaces
{
    internal interface IViewObserver
    {
        public ObservableCollection<IPaneView> Panes { get; }

        void Attach(IPaneView observer);

        void Detach(IPaneView observer);

        void Notify(ViewEventArgs args);
    }
}