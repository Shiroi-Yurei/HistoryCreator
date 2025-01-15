using HistoryCreator.Models.Data.Enum;
using HistoryCreator.Models.Data.Manager;
using HistoryCreator.Models.Data.Project;
using HistoryCreator.Ressources;
using HistoryCreator.Ressources.Core;
using HistoryCreator.Ressources.UI;
using HistoryCreator.Views.Dialog;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;

namespace HistoryCreator.ViewModel
{
    public class HomeViewModel : ViewModelBase
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

        public ObservableCollection<TabItem> OpenViewCollection { get; private set; }

        #region Application Menu Commands region

        public DelegateCommand<object> NewProjectCommand { get; private set; }
        public DelegateCommand<object> OpenProjectCommand { get; private set; }
        public DelegateCommand<object> SaveProjectCommand { get; private set; }
        public DelegateCommand<object> AboutUsCommand { get; private set; }

        #endregion Application Menu Commands region

        #region Projet Ribbon Commands region

        public DelegateCommand<object> CreateCharacterCommand { get; private set; }

        #endregion

        public HomeViewModel()
        {
            InitView();
            CurrentProject = new Project();
        }

        private void InitView()
        {
            OpenViewCollection = new ObservableCollection<TabItem>();

            OpenViewCollection.Add(new TabItem
            {
                Header = "Hello",
                Content = "World"
            });
            OpenViewCollection.Add(new TabItem
            {
                Header = "Test 1",
                Content = "Premier test"
            });

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
            OpenViewCollection.Add(new TabItem()
            {
                Header = "Personnage",
                Content = "Yes ça fonctionne"
            });
        }
    }
}