using Marliazen.Software.Core.DataManager.Interfaces;

namespace Marliazen.Software.Core.DataManager.Entity
{
    /// <summary>
    /// Interface représentant tout objet pouvant être exporter ou importer
    /// </summary>
    public interface IExternalEntity : IExportable, IImportable
    {
        public string FileName { get; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
