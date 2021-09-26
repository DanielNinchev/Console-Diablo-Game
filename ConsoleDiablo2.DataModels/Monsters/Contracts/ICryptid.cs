namespace ConsoleDiablo2.DataModels.Monsters.Contracts
{
    public interface ICryptid : IMonster
    {
        Bonus DrainMana { get; set; }

        Bonus Monstrosity { get; set; }
    }
}
