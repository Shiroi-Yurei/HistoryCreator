using HistoryCreator.Models.Data.Config;
using HistoryCreator.Models.Data.Enum;
using HistoryCreator.Models.Data.Manager;
using HistoryCreator.Models.Data.Project;
using HistoryCreator.Ressources;
using HistoryCreator.Ressources.Characters.View;
using Marliazen.Software.Core;
using Marliazen.Software.Core.CommandsManager;
using Marliazen.Software.Core.Enums;
using Marliazen.Share.UI.Layout.Interfaces;
using Marliazen.Share.UI.Manager.View;
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

        private IProject _currentProject;

        public IProject CurrentProject
        {
            get => _currentProject;
            set
            {
                if (_currentProject != value)
                {
                    _currentProject = value;
                    OnPropertyChanged(nameof(CurrentProject));
                    CommandsManager.GetInstance().UpdateCommands(nameof(RootViewModel));
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

        #region
        public DelegateCommand<object> CreateCharacterCommand { get; private set; }
        public DelegateCommand<object> OpenCharacterList { get; private set; }
        #endregion

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
            ViewRegister.GetInstance().Register(nameof(CharacterFormView), typeof(CharacterFormView));
            ViewRegister.GetInstance().Register(nameof(CharacterListView), typeof(CharacterListView));

            _viewsManager.AddStaticView("HomeView");

            var config = AppConfig.GetInstance();

            InitCommands();
        }

        private void InitCommands()
        {
            NewProjectCommand = new DelegateCommand<object>(HandleNewProjectCommand, CanHandleNewProjectCommand);
            OpenProjectCommand = new DelegateCommand<object>(HandleOpenProjectCommand, CanHandleOpenProjectCommand);

            CreateCharacterCommand = new DelegateCommand<object>(HandleCreateCharacterCommand, CanHandleCreateCharacterCommand);
            OpenCharacterList = new DelegateCommand<object>(HandleOpenCharacterListCommand, CanHandleOpenCharacterListCommand);

            CommandsManager.GetInstance().Register(nameof(RootViewModel), NewProjectCommand);
            CommandsManager.GetInstance().Register(nameof(RootViewModel), OpenProjectCommand);
            CommandsManager.GetInstance().Register(nameof(RootViewModel), OpenCharacterList);
            CommandsManager.GetInstance().Register(nameof(RootViewModel), CreateCharacterCommand);
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
                if (r == DialogResult.Ok)
                {
                    CurrentProject = p;
                }
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
                {
                    importProject.IsInitialized = true;
                    CurrentProject = importProject;
                }
            }
        }

        private bool CanHandleOpenCharacterListCommand(object obj)
        {
            return true; // CurrentProject.IsInitialized;
        }

        private bool CanHandleCreateCharacterCommand(object obj)
        {
            return CurrentProject.IsInitialized;
        }

        private void HandleOpenCharacterListCommand(object obj)
        {
            if (obj is string nameview)
            {
                _viewsManager.AddView(nameview);
            }
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