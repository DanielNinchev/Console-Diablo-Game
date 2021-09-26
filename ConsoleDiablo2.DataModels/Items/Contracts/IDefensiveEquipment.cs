namespace ConsoleDiablo2.DataModels.Items.Contracts
{
    public interface IDefensiveEquipment : IItem
    {
        Bonus Defense { get; set; }

        Bonus Resistance { get; set; }
    }
}
