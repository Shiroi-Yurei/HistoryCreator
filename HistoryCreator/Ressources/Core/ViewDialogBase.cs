using HistoryCreator.Ressources.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HistoryCreator.Ressources.Core
{
    public abstract class ViewDialogBase : Window
    {
        event EventHandler<DialogResult> RequestClose;
    }
}
