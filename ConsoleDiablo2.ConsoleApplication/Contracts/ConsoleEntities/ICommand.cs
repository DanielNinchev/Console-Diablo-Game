using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

namespace ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities
{
    public interface IMenuCommand
    {
        IMenu Execute(params object[] args);
    }
}
