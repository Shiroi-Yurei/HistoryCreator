using HistoryCreator.Models.Data.Project;
using HistoryCreator.Ressources;
using HistoryCreator.Ressources.Core;
using HistoryCreator.Ressources.Core.Enums;

namespace HistoryCreator.ViewModel.Dialog
{
    public class NewProjectViewModel : ViewModelDialogBase
    {
        private IProject _currentProject;
        private string _defaultProjectPath = Constants.ApplicationRootFolder;

        public string Header => "Création d'un nouveau projet";
        
        public IProject CurrentProject
        {
            get => _currentProject;
            private set {
                if (_currentProject != value)
                   _currentProject = value;
            }
        }

        public DelegateCommand<object> ValidateCommand { get; private set; }
        public DelegateCommand<object> CancelCommand { get; private set; }

        public NewProjectViewModel() {
            CurrentProject = new Project(_defaultProjectPath);

            InitCommands();
        }

        private void InitCommands() {
            ValidateCommand = new DelegateCommand<object>(ExecuteValidateCommand, CanExecuteValidateCommand);
            CancelCommand = new DelegateCommand<object>(ExecuteCancelCommand, CanExecuteCancelCommand);
        }

        public bool CanExecuteValidateCommand(object param)
        {
            return true;
        }

        public bool CanExecuteCancelCommand(object param)
        {
            return true;
        }

        public void ExecuteValidateCommand(object param)
        {
            if (CurrentProject.Save())
            {
                RequestClose.Invoke(this, DialogResult.Ok);
            }
            else
                RequestClose.Invoke(this, DialogResult.Cancel);
        }

        public void ExecuteCancelCommand(object param) { 
            
        }

        public event EventHandler<DialogResult> RequestClose;
    }
}
