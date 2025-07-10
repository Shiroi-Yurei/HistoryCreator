namespace Marliazen.Share.UI.Manager.View.Interfaces
{
    public interface IViewsRegister
    {
        Type Call(string viewName);

        bool Register(string viewName, Type type);
    }
}