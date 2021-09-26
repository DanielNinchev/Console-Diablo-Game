namespace ConsoleDiablo2.DataModels.Items.Contracts
{
    public interface IArmor : IDefensiveEquipment
    {
        Bonus Life { get; set; }
    }
}
