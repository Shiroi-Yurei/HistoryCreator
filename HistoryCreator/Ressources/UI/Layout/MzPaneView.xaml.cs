using HistoryCreator.Ressources.Core;
using HistoryCreator.Ressources.UI.Layout.Interfaces;
using HistoryCreator.Ressources.UI.Manager.View;
using System.Windows;
using System.Windows.Controls;

namespace HistoryCreator.Ressources.UI.Layout
{
    /// <summary>
    /// Logique d'interaction pour MzPaneView.xaml
    /// </summary>
    public partial class MzPaneView : TabItem, IPaneView
    {
        private int _paneId = -1;
        private bool _isStatic;

        public int PaneId => _paneId;

        public bool IsStatic => _isStatic;

        public DelegateCommand<object> CloseViewCommand { get; private set; }


        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object),
                typeof(MzPaneView), new PropertyMetadata(null, HeaderPropertyChangedCallback));

        public MzPaneView(int paneId, bool isStatic = false)
        {
            InitializeComponent();

            _isStatic = isStatic;

            ((TabItem)this).Loaded += MzPaneView_Loaded;

            CloseViewCommand = new DelegateCommand<object>(HandleCloseViewCommand, CanHandleCloseViewCommand);
        }

        private void MzPaneView_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsStatic)
                IsSelected = true;
        }

        private static void HeaderPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MzPaneView control)
            {
                control.Header = (object)e.NewValue;
            }
        }

        void IPaneView.Update(ViewEventArgs args)
        {
            ViewObserver.GetInstance().Notify(args);
        }

        private bool CanHandleCloseViewCommand(object obj)
        {
            return !_isStatic;
        }

        private void HandleCloseViewCommand(object obj)
        {
            ((IPaneView)this).Update(new ViewEventArgs(this, ViewActionEnum.Close));

            //if (sender is Button button &&
            //    button.CommandParameter is TabItem control &&
            //    ItemsSource is ObservableCollection<TabItem> source)
            //{
            //    source.Remove(control);
            //}
        }
    }
}