using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryCreator.Ressources.Core.DataManager.Interfaces
{
    public interface IEditeable
    {
        DateTime ModificationDate { get; set; }
        
        bool Save();
        bool Cancel();
    }
}
