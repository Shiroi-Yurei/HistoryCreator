using HistoryCreator.Ressources.Core.DataManager.Entity;

namespace HistoryCreator.Models.Data.Manager.Interfaces
{
    public interface IFileManager
    {
        bool Export(string path, IExternalEntity obj);

        T? Import<T>(string Path);
    }
}