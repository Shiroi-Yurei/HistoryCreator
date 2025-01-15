using HistoryCreator.Models.Data.Enum;
using HistoryCreator.Ressources.Core.DataManager.Entity;
using HistoryCreator.Ressources.Core.DataManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryCreator.Models.Data.Project
{
    public interface IProject : IExternalEntity, IEditeable
    {
        string Name { get; }
        string Path { get; }
        ProjectType TypeOfProject { get; }
        StorageType TypeOfStorage { get; }
    }
}
