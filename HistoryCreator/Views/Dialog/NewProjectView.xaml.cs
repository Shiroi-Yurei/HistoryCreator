using System.Windows;
using HistoryCreator.Models.Data.Project;
using HistoryCreator.ViewModel.Dialog;
using Marliazen.Software.Core.Enums;

namespace HistoryCreator.Views.Dialog
{
    /// <summary>
    /// Logique d'interaction pour NewProjectView.xaml
    /// </summary>
    public partial class NewProjectView : Window
    {
        private Action<DialogResult, IProject?> _closeAction;

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
                if (e == Marliazen.Software.Core.Enums.DialogResult.Cancel)
                {
                    _closeAction.Invoke(Marliazen.Software.Core.Enums.DialogResult.Cancel, null);
                    Close();
                }
                else if (e == Marliazen.Software.Core.Enums.DialogResult.Ok)
                {
                    _closeAction.Invoke(Marliazen.Software.Core.Enums.DialogResult.Ok, viewModel.CurrentProject);
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