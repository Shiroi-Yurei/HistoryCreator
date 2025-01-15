using HistoryCreator.Models.Data.Manager.Interfaces;
using HistoryCreator.Ressources.Core.DataManager.Entity;
using Newtonsoft.Json;
using System.IO;

namespace HistoryCreator.Models.Data.Manager
{
    public class JsonManager : IFileManager
    {
        public JsonManager()
        { }

        private void ValidatePath(string value, out string correctPath)
        {
            if (value.Contains("file:\\"))
                correctPath = value.Remove(0, 6);
            else
                correctPath = value;
        }

        public bool Export(string path, IExternalEntity obj)
        {
            try
            {
                ValidatePath(path, out var correctPath);

                if (!Directory.Exists(correctPath))
                    Directory.CreateDirectory(correctPath);

                var filePath = Path.Combine(correctPath, obj.FileName);

                if (!File.Exists(filePath))
                    obj.CreationDate = DateTime.Now;

                obj.ModificationDate = DateTime.Now;
                var export = JsonConvert.SerializeObject(obj, Formatting.Indented);

                File.WriteAllText(filePath, export);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public T? Import<T>(string path)
        {
            T? ret = default;
            try
            {
                ValidatePath(path, out var correctPath);

                if (!File.Exists(correctPath))
                    return ret;

                var content = File.ReadAllText(correctPath);

                return JsonConvert.DeserializeObject<T>(content);
            }
            catch
            {
                return ret;
            }
        }
    }
}