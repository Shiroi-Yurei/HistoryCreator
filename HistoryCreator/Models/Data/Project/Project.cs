using HistoryCreator.Models.Data.Enum;
using HistoryCreator.Models.Data.Manager;
using HistoryCreator.Ressources;
using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace HistoryCreator.Models.Data.Project
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Project : IProject
    {
        private bool _isCreating = false;

        private Project _oldValue;

        private string _name;
        private string _path;

        private ProjectType _typeOfProject;
        private StorageType _typeOfStorage;

        private DateTime _creationDate;
        private DateTime _modificationDate;

        [JsonProperty]
        public string Name { 
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;

                }
            }
        }

        [JsonProperty]
        public string Path { 
            get => _path; 
            set
            {
                if (_path != value)
                {
                    if (value.Contains("file:\\"))
                        value = value.Remove(0, 6);
                    _path = value;
                }
            } 
        }

        [JsonProperty]
        public ProjectType TypeOfProject 
        { 
            get => _typeOfProject; 
            set
            {
                if (_typeOfProject != value)
                    _typeOfProject = value;
            }
        }

        [JsonProperty]
        public StorageType TypeOfStorage
        {
            get
            {
                return _typeOfStorage;
            }
            set
            {
                if (_typeOfStorage != value)
                    _typeOfStorage = value;
            }
        }

        [JsonProperty]
        public DateTime ModificationDate 
        { 
            get => _modificationDate; 
            set
            {
                if (_modificationDate != value)
                    _modificationDate = value;
            }
        }

        [JsonProperty]
        public DateTime CreationDate
        {
            get => _creationDate;
            set
            {
                if (!_isCreating && _creationDate != value)
                    _creationDate = value;
            }
        }

        public string FileName => Constants.MainFileProjectName;

        public Project(string? defaultPath = null) {
            TypeOfProject = ProjectType.NotDefined;
            TypeOfStorage = StorageType.Unknown;

            if (defaultPath != null)
                Path = defaultPath;
        }

        public bool Save()
        {
            if (Directory.GetCurrentDirectory() != Path)
                Directory.SetCurrentDirectory(Path);

            var mainProjectDirectory = Path + "\\" + Constants.ProjectDirectoryName;

            if (!Directory.Exists(mainProjectDirectory + "\\" + Name))
            {
                CreationDate = DateTime.Now;
                Path = mainProjectDirectory + "\\" + Name;
                _isCreating = true;
            }
            else
            {
                MessageBox.Show("Projet déjà existant", "HAC - History Assistant Creator",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            DataStorageManager.Instance.Export(TypeOfStorage, Path, this);

            return true;
        }

        public bool Load()
        {
            throw new NotImplementedException();
        }

        public bool Cancel()
        {
            throw new NotImplementedException();
        }

        public bool Export()
        {
            throw new NotImplementedException();
        }

        public bool Import()
        {
            throw new NotImplementedException();
        }
    }
}
