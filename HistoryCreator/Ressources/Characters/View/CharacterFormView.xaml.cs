using System.Windows.Controls;
using HistoryCreator.Ressources.Characters.ViewModels;

namespace HistoryCreator.Ressources.Characters.View
{
    /// <summary>
    /// Logique d'interaction pour CharacterFormView.xaml
    /// </summary>
    public partial class CharacterFormView : UserControl
    {
        public CharacterFormView()
        {
            InitializeComponent();

            DataContext = new CharacterFormViewModel();
        }
    }
}