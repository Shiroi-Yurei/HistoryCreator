using HistoryCreator.Ressources.Core.Enums;
using HistoryCreator.Ressources.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryCreator.Ressources.Core
{
    public abstract class ViewModelDialogBase : IViewModelBase
    {
        protected ViewModelDialogBase() { }

        public string Header => throw new NotImplementedException();

        event EventHandler<DialogResult> RequestClose;

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
