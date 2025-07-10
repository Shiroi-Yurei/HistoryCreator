using System.IO;
using HistoryCreator.Ressources;
using Marliazen.Software.Core.DataManager.Entity;

namespace HistoryCreator.Models.Data.Config
{
    public class AppConfig : IExternalEntity
    {
        private static AppConfig _instance;

        private bool _isCreating = false;

        private DateTime _creationDate;
        private DateTime _modificationDate;

        public string FileName => Constants.ProjectDirectoryName;

        public DateTime CreationDate
        {
            get => _creationDate;
            set
            {
                if (!_isCreating && _creationDate != value)
                    _creationDate = value;
            }
        }

        public DateTime ModificationDate
        {
            get => _modificationDate;
            set
            {
                if (_modificationDate != value)
                    _modificationDate = value;
            }
        }

        public bool Export()
        {
            var mainProjectDirectory = Constants.ApplicationRootFolder
                + "\\" + Constants.ProjectDirectoryName;

            var test = "";

            return true;
        }

        public bool Import()
        {
            var mainProjectDirectory = Constants.ApplicationRootFolder
                + "\\" + Constants.ConfigApplicationFile;

            if (!File.Exists(mainProjectDirectory))
            {
                return false;
            }

            var test = "";

            return false;
        }

        public static AppConfig GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AppConfig();
                _instance.Import();
            }

            return _instance;
        }
    }
}