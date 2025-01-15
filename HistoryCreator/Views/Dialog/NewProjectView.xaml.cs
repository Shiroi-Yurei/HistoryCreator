using HistoryCreator.Models.Data.Project;
using HistoryCreator.Ressources.Core.Enums;
using HistoryCreator.ViewModel.Dialog;
using System.Windows;

namespace HistoryCreator.Views.Dialog
{
    /// <summary>
    /// Logique d'interaction pour NewProjectView.xaml
    /// </summary>
    public partial class NewProjectView : Window
    {
        Action<DialogResult, IProject?> _closeAction;

        public NewProjectView(Action<DialogResult, IProject?> closeAction)
        {
            InitializeComponent();

            _closeAction = closeAction;

            var dc = new NewProjectViewModel();
            dc.RequestClose += DataContext_RequestClose;

            this.DataContext = dc;
        }

        private void DataContext_RequestClose(object? sender, DialogResult e)
        {
            if (sender is NewProjectViewModel viewModel)
            { 
                if (e == Ressources.Core.Enums.DialogResult.Cancel)
                {
                    _closeAction.Invoke(Ressources.Core.Enums.DialogResult.Cancel, null);
                    Close();
                }
                else if (e == Ressources.Core.Enums.DialogResult.Ok)
                {
                    _closeAction.Invoke(Ressources.Core.Enums.DialogResult.Ok, viewModel.CurrentProject);
                    Close();
                }
                else
                {
                    throw new NotSupportedException("[NewProjectView] Result of close request was not support !!!");
                }
            }
        }
    }
}
