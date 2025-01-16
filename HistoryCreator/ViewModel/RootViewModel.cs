using HistoryCreator.Models.Data.Enum;
using HistoryCreator.Models.Data.Manager;
using HistoryCreator.Models.Data.Project;
using HistoryCreator.Ressources;
using HistoryCreator.Ressources.Core;
using HistoryCreator.Ressources.UI;
using HistoryCreator.Ressources.UI.Layout;
using HistoryCreator.Ressources.UI.Layout.Interfaces;
using HistoryCreator.Ressources.UI.Manager.View;
using HistoryCreator.Views.Dialog;
using HistoryCreator.Views.HomeParts;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;

namespace HistoryCreator.ViewModel
{
    public class RootViewModel : ViewModelBase
    {
        public override string Header { get; }

        private Project _currentProject;

        public Project CurrentProject
        {
            get => _currentProject;
            set
            {
                if (_currentProject != value)
                {
                    _currentProject = value;
                    OnPropertyChanged(nameof(CurrentProject));
                }
            }
        }

        private readonly ViewManager _viewsManager;

        public ObservableCollection<IPaneView> OpenViewCollection => _viewsManager.Views;

        #region Application Menu Commands region

        public DelegateCommand<object> NewProjectCommand { get; private set; }
        public DelegateCommand<object> OpenProjectCommand { get; private set; }
        public DelegateCommand<object> SaveProjectCommand { get; private set; }
        public DelegateCommand<object> AboutUsCommand { get; private set; }

        #endregion Application Menu Commands region

        #region Projet Ribbon Commands region

        public DelegateCommand<object> CreateCharacterCommand { get; private set; }

        #endregion Projet Ribbon Commands region

        public RootViewModel()
        {
            _viewsManager = new ViewManager();

            InitView();
            CurrentProject = new Project();
        }

        private void InitView()
        {
            ViewRegister.GetInstance().Register(nameof(HomeView), typeof(HomeView));

            _viewsManager.AddView("HomeView", true);

            InitCommands();
        }

        private void InitCommands()
        {
            NewProjectCommand = new DelegateCommand<object>(HandleNewProjectCommand, CanHandleNewProjectCommand);
            OpenProjectCommand = new DelegateCommand<object>(HandleOpenProjectCommand, CanHandleOpenProjectCommand);

            CreateCharacterCommand = new DelegateCommand<object>(HandleCreateCharacterCommand, CanHandleCreateCharacterCommand);
        }

        private bool CanHandleNewProjectCommand(object? obj)
        {
            return true;
        }

        private bool CanHandleOpenProjectCommand(object? obj)
        {
            return true;
        }

        private void HandleNewProjectCommand(object? obj)
        {
            var newProject = new NewProjectView((r, p) =>
            {
            });
            newProject.ShowDialog();
        }

        private void HandleOpenProjectCommand(object? obj)
        {
            var dialog = new OpenFolderDialog();

            var path = Path.Combine(Constants.ApplicationRootFolder, Constants.ProjectDirectoryName);

            dialog.DefaultDirectory = path;
            dialog.InitialDirectory = path;
            dialog.ShowDialog();

            var selectedPath = dialog.FolderName;
            var projectPath = Path.Combine(selectedPath, Constants.MainFileProjectName);
            var typeOfFile = projectPath.Split('.')[^1];

            if (StorageType.TryParse(typeOfFile, true, out StorageType storageType))
            {
                var importProject = DataStorageManager.Instance.Import<Project>(storageType, projectPath);
                if (importProject != null)
                    CurrentProject = importProject;
            }
        }

        private bool CanHandleCreateCharacterCommand(object obj)
        {
            return true;
        }

        private void HandleCreateCharacterCommand(object obj)
        {
            if (obj is string nameView)
            {
                _viewsManager.AddView(nameView);
            }
        }
    }
}