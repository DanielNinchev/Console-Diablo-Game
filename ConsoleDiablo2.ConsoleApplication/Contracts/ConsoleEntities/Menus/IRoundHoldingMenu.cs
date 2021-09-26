namespace ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus
{
    public interface IRoundHoldingMenu : IInfoHoldingMenu
    {
         int Round { get; set; }
    }
}
