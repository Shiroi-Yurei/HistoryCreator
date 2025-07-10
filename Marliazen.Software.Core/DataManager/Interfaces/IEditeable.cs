namespace Marliazen.Software.Core.DataManager.Interfaces
{
    public interface IEditeable
    {
        DateTime ModificationDate { get; set; }

        bool Save();

        bool Cancel();
    }
}