namespace ConsoleDiablo2.DataModels.Items.Contracts
{
    public interface IWeapon : IItem
    {
        Bonus Accuracy { get; set; }

        Bonus Damage { get; set; }

        Bonus ChanceOfCriticalHit { get; set; }

        Bonus DamageToMonsterType { get; set; }

        Bonus LifeTap { get; set; }

        Bonus ManaTap { get; set; }

        Bonus SkillBonus { get; set; }

        Bonus ElementalSkillDamage { get; set; }

        Bonus AllSkillsBonus { get; set; }

        bool IgnoreTargetsDefense { get; set; }
    }
}
