using HistoryCreator.Ressources.UI.Manager.View.Interfaces;

namespace HistoryCreator.Ressources.UI.Manager.View
{
    internal class ViewRegister : IViewsRegister
    {
        private static IViewsRegister _instance;

        private Dictionary<string, Type> Views;

        private ViewRegister()
        {
            Views = new Dictionary<string, Type>();
        }

        // TODO : Ajouter la gestion des erreurs

        public Type? Call(string viewName)
        {
            if (Views.ContainsKey(viewName))
                return Views[viewName];

            return null;
        }

        public bool Register(string viewName, Type type)
        {
            return Views.TryAdd(viewName, type);
        }

        public static IViewsRegister GetInstance()
        {
            if (_instance == null)
                _instance = new ViewRegister();

            return _instance;
        }
    }
}