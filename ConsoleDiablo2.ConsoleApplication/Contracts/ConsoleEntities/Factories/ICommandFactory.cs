namespace ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories
{
    public interface ICommandFactory
    {
        IMenuCommand CreateCommand(string commandName);
    }
}
