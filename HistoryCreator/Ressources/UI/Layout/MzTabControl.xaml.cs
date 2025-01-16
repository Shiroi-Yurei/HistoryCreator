using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace HistoryCreator.Ressources.UI.Layout
{
    /// <summary>
    /// Logique d'interaction pour MzTabControl.xaml
    /// </summary>
    public partial class MzTabControl : UserControl
    {
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable),
                typeof(MzTabControl), new PropertyMetadata(null, ItemsSourcePropertyChangedCallback));

        public MzTabControl()   
        {
            InitializeComponent();
        }

        private static void ItemsSourcePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MzTabControl control)
            {
                control.ItemsSource = (IEnumerable)e.NewValue;
                control.RootControl.ItemsSource = (IEnumerable)e.NewValue;
            }
        }
    }
}