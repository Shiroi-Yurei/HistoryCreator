using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryCreator.Ressources.UI.Manager.View.Interfaces
{
    internal interface IViewsRegister
    {
        Type Call(string viewName);

        bool Register(string viewName, Type type);
    }
}
