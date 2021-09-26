using ConsoleDiablo2.ConsoleApplication.ConsoleEntities;

namespace ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories
{
    public interface ILabelFactory
    {
        ILabel CreateLabel(string content, Position position, bool isHidden = false);

        IButton CreateButton(string content, Position position, bool isHidden = false, bool isField = false);
    }
}
