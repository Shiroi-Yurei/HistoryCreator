using Marliazen.Share.UI.Layout;
using Marliazen.Share.UI.Layout.Interfaces;
using Marliazen.Share.UI.Manager.View.Interfaces;
using System.Collections.ObjectModel;

namespace Marliazen.Share.UI.Manager.View
{
    public class ViewManager
    {
        private int _currentPaneId = 0;
        private IViewObserver _observer = ViewObserver.GetInstance();
        private readonly IViewsRegister _register;

        public int CurrentPaneId { get => _currentPaneId; }
        public ObservableCollection<IPaneView> Views { get => _observer.Panes; }

        public ViewManager()
        {
            _register = ViewRegister.GetInstance();
        }

        public void AddStaticView(string nameView)
        {
            BaseAddView(nameView, true);
        }

        public void AddView(string nameView)
        {
            BaseAddView(nameView, false);
        }

        private void BaseAddView(string nameView, bool defaultView)
        {
            var viewType = _register.Call(nameView);

            if (viewType != null)
            {
                var instance = Activator.CreateInstance(viewType);

                var paneView = new MzPaneView(_currentPaneId, defaultView)
                {
                    Header = nameView,
                    Content = instance
                };

                _currentPaneId++;
                _observer.Attach(paneView);
                paneView.IsSelected = true;
            }
        }
    }
}