using Marliazen.Share.UI.Layout.Interfaces;

namespace Marliazen.Share.UI.Manager.View
{
    public class ViewEventArgs
    {
        public IPaneView Sender;
        public ViewActionEnum Args;

        public ViewEventArgs(IPaneView sender, ViewActionEnum args)
        {
            Sender = sender;
            Args = args;
        }
    }
}