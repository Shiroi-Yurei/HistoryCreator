namespace Marliazen.Software.Core.CommandsManager
{
    public interface ICommandsManager
    {
        /// <summary>
        /// Méthode d'enregistrement des commands dans le CommandManager
        /// </summary>
        /// <param name="name">Non de la class</param>
        /// <param name="command">Command</param>
        /// <returns></returns>
        public bool Register(string name, DelegateCommand<object> command);

        public void UpdateCommands(string viewName);
    }
}