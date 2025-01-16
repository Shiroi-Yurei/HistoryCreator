using HistoryCreator.Ressources.UI.Manager.View;

namespace HistoryCreator.Ressources.UI.Layout.Interfaces
{
    public interface IPaneView
    {
        public int PaneId { get; }

        public bool IsStatic { get; }

        public void Update(ViewEventArgs args);
    }
}