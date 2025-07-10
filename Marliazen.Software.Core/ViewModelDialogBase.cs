using System.ComponentModel;
using Marliazen.Software.Core.Enums;
using Marliazen.Software.Core.Interfaces;

namespace Marliazen.Software.Core
{
    public abstract class ViewModelDialogBase : IViewModelBase
    {
        protected ViewModelDialogBase()
        { }

        public string Header => throw new NotImplementedException();

        private event EventHandler<DialogResult> RequestClose;

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}