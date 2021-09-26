using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class CreateANewCharacterMenuCommand : MenuCommand
    {
        public CreateANewCharacterMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {

        }
    }
}
