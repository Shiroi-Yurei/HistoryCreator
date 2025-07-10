using Marliazen.Software.Core.Enums;

namespace Marliazen.Software.Core
{
    public abstract class ViewDialogBase
    {
        private event EventHandler<DialogResult> RequestClose;
    }
}