using Marliazen.Software.Core.Exception;

namespace Marliazen.Software.Core.CommandsManager
{
    public class CommandsManager : ICommandsManager
    {
        private static ICommandsManager _instance;

        private Dictionary<string, List<DelegateCommand<object>>> _dictionary;

        private CommandsManager()
        {
            _dictionary = new Dictionary<string, List<DelegateCommand<object>>>();
        }

        /// <inheritdoc />
        public bool Register(string name, DelegateCommand<object> command)
        {
            if (!_dictionary.ContainsKey(name))
            {
                _dictionary.Add(name, new List<DelegateCommand<object>>() { command });
            }
            else if (_dictionary.TryGetValue(name, out var list))
            {
                list.Add(command);
            }

            return false;
        }

        public void UpdateCommands(string viewName)
        {
            try
            {
                if (!_dictionary.ContainsKey(viewName))
                    throw new KeyNotFoundException(viewName);

                foreach (var commandList in _dictionary[viewName])
                    commandList.RaiseCanExecuteChanged();
            }
            catch
            {
                new CommandNotExists();
            }
        }

        public static ICommandsManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CommandsManager();
            }

            return _instance;
        }
    }
}