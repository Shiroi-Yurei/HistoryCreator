using Marliazen.Share.UI.Manager.View;

namespace Marliazen.Share.UI.Layout.Interfaces
{
    public interface IPaneView
    {
        public int PaneId { get; }

        public bool IsStatic { get; }

        public void Update(ViewEventArgs args);
    }
}