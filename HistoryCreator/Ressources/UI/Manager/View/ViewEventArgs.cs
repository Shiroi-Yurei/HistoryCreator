using HistoryCreator.Ressources.UI.Layout.Interfaces;

namespace HistoryCreator.Ressources.UI.Manager.View
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