using HistoryCreator.ViewModel;
using System.Windows;

namespace HistoryCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RootView : Window
    {
        public RootView()
        {
            InitializeComponent();

            DataContext = new RootViewModel();
        }
    }
}