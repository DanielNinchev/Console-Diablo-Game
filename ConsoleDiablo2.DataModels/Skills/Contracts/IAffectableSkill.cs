namespace ConsoleDiablo2.DataModels.Skills.Contracts
{
    public interface IAffectableSkill : ISkill
    {
        int FirstLevelValue { get; set; }
    }
}
