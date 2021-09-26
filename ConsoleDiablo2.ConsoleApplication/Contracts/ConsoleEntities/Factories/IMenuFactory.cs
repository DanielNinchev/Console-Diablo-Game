using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

namespace ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories
{
    public interface IMenuFactory
    {
        IMenu CreateMenu(string menuName);
    }
}
