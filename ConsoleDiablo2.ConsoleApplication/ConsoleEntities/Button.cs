using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities
{
    public class Button : IButton
    {
        public Button(string text, Position position, bool isHidden = false, bool isField = false)
        {
            this.Text = text;
            this.Position = position;
            this.IsHidden = isHidden;
            this.IsField = isField;
        }
        public bool IsField { get; }

        public string Text { get; }

        public bool IsHidden { get; }

        public Position Position { get; }
    }
}
