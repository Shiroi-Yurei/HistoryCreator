using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
namespace HistoryCreator.Ressources
{
    public class Constants
    {
        /// <summary>
        /// Chemin d'accès à la racine de l'application
        /// </summary>
        public static string ApplicationRootFolder = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase);

        /// <summary>
        /// Nom du répertoire par défaut des projets
        /// </summary>
        public static string ProjectDirectoryName = "project";

        /// <summary>
        /// Nom du fichier principal d'un projet
        /// </summary>
        public static string MainFileProjectName = "project.json";
    }
}
