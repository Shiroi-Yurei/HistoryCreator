using HistoryCreator.Models.Data.Enum;
using HistoryCreator.Ressources.Core.DataManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
