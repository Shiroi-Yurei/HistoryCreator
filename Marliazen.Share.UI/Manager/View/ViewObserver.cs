using Marliazen.Share.UI.Layout.Interfaces;
using Marliazen.Share.UI.Manager.View.Interfaces;
using System.Collections.ObjectModel;

namespace Marliazen.Share.UI.Manager.View
{
    internal class ViewObserver : IViewObserver
    {
        private static IViewObserver _instance;

        private ObservableCollection<IPaneView> _panes;

        public ViewObserver()
        {
            _panes = new ObservableCollection<IPaneView>();
        }

        public ObservableCollection<IPaneView> Panes => _panes;

        public void Attach(IPaneView observer)
        {
            _panes.Add(observer);
        }

        public void Detach(IPaneView observer)
        {
            _panes.Remove(observer);
        }

        public void Notify(ViewEventArgs obj)
        {
            if (obj.Args == ViewActionEnum.Close)
                Detach(obj.Sender);
        }

        public static IViewObserver GetInstance()
        {
            if (_instance == null)
                _instance = new ViewObserver();
            return _instance;
        }
    }
}