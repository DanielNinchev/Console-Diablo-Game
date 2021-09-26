using ConsoleDiablo2.DataModels.Monsters.Contracts;

namespace ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus
{
    public interface IMonsterHoldingMenu : IInfoHoldingMenu
    {
        IMonster Monster { get; set; }
    }
}
