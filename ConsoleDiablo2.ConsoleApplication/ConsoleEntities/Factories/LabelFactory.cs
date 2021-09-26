using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Factories
{
    public class LabelFactory : ILabelFactory
    {
        public IButton CreateButton(string content, Position position, bool isHidden = false, bool isField = false)
        {
            return new Button(content, position, isHidden, isField);
        }

        public ILabel CreateLabel(string content, Position position, bool isHidden = false)
        {
            return new Label(content, position, isHidden);
        }
    }
}
