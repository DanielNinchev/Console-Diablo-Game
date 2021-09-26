namespace ConsoleDiablo2.DataModels.Monsters.Contracts
{
    public interface IUndead : IMonster
    {
        Bonus Revitalization { get; set; }

        Bonus Painlessness { get; set; }
    }
}
