using HistoryCreator.Models.Data.Enum;
using Marliazen.Software.Core.DataManager.Entity;

namespace HistoryCreator.Models.Data.Manager
{
    public interface IDataStorageManager
    {
        public static IDataStorageManager Instance { get; }

        bool Export(StorageType storageType, string path, IExternalEntity obj);

        T? Import<T>(StorageType storage, string Path);

        object Import(StorageType storage, string connectionPath, string query);
    }
}