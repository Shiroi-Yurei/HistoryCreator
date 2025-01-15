using HistoryCreator.Models.Data.Enum;
using HistoryCreator.Models.Data.Manager.Interfaces;
using HistoryCreator.Ressources.Core.DataManager.Entity;

namespace HistoryCreator.Models.Data.Manager
{
    /// <summary>
    /// Manager du stockage des données permettant l'import/export
    /// </summary>
    public class DataStorageManager : IDataStorageManager
    {
        private const string removeFilePathPart = "file:\\";

        private static IDataStorageManager _instance;

        private IFileManager _jsonManager;

        private DataStorageManager()
        {
            _jsonManager = new JsonManager();
        }

        public bool Export(StorageType storageType, string path, IExternalEntity obj)
        {
            var ret = false;
            var manager = SplitterManager(storageType);

            if (manager != null)
                ret = manager.Export(path, obj);

            return ret;
        }

        public T? Import<T>(StorageType storage, string path)
        {
            T? ret = default;

            var manager = SplitterManager(storage);
            if (manager != null)
                ret = manager.Import<T>(path);

            return ret;
        }

        public object Import(StorageType storage, string connectionPath, string query)
        {
            throw new NotImplementedException();
        }

        private IFileManager SplitterManager(StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.JSON:
                    return _jsonManager;

                case StorageType.Unknown:
                default:
                    return null;
            }
        }

        public static IDataStorageManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataStorageManager();

                return _instance;
            }
        }
    }
}