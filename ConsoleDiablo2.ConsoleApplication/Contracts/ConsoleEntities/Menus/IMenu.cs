namespace ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus
{
    public interface IMenu
    {
        IButton CurrentOption { get; }

        ILabel[] Labels { get; }

        IButton[] Buttons { get; }

        string ErrorMessage { get; set; }

        string BackMenu { get; }

        bool IsReturningMenu { get; set; }

        void NextOption();

        void PreviousOption();

        IMenu ExecuteCommand();

        void Open();
    }
}
