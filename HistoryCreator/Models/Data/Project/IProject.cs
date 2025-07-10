using HistoryCreator.Models.Data.Enum;
using Marliazen.Software.Core.DataManager.Entity;
using Marliazen.Software.Core.DataManager.Interfaces;

namespace HistoryCreator.Models.Data.Project
{
    public interface IProject : IExternalEntity, IEditeable
    {
        string Name { get; }
        string Path { get; }
        bool IsInitialized { get; set; }
        ProjectType TypeOfProject { get; }
        StorageType TypeOfStorage { get; }
    }
}