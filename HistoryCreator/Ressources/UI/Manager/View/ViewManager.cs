using HistoryCreator.Ressources.UI.Layout;
using HistoryCreator.Ressources.UI.Layout.Interfaces;
using HistoryCreator.Ressources.UI.Manager.View.Interfaces;
using HistoryCreator.Views.HomeParts;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace HistoryCreator.Ressources.UI.Manager.View
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

        public void AddView(string nameView, bool homeView = false)
        {
            var viewType = _register.Call(nameView);

            if (viewType != null)
            {
                var instance = Activator.CreateInstance(viewType);

                var paneView = new MzPaneView(_currentPaneId, homeView)
                {
                    Header = nameView,
                    Content = instance
                };

                _currentPaneId++;
                _observer.Attach(paneView);
            }
        }
    }
}