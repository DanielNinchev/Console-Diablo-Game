namespace ConsoleDiablo2.DataModels.Monsters.Contracts
{
    public interface IDemon : IMonster
    {
        Bonus Immolation { get; set; }

        Bonus Paranormality { get; set; }
    }
}
