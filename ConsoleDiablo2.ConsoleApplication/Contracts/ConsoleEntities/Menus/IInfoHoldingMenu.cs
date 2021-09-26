namespace ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus
{
    public interface IInfoHoldingMenu : IMenu
    {
        int Id { get; set; }

        void PassInformation(params object[] info);
    }
}
