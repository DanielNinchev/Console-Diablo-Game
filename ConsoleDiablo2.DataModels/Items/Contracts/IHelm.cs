namespace ConsoleDiablo2.DataModels.Items.Contracts
{
    public interface IHelm : IDefensiveEquipment
    {
        Bonus Mana { get; set; }
    }
}
