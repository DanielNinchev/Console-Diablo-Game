using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class SignUpMenuCommand : MenuCommand
    {
        public SignUpMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {
        }
    }
}
