namespace ConsoleDiablo2.DataModels.Items.Contracts
{
    public interface IShield : IDefensiveEquipment
    {
        Bonus ChanceToBlock { get; set; }

        Bonus SmiteDamage { get; set; }
    }
}
