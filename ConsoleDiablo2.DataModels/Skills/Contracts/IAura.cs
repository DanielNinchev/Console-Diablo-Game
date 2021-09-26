namespace ConsoleDiablo2.DataModels.Skills.Contracts
{
    public interface IAura : ISkill
    {
        double RoundDuration { get; set; }

        void DeactivateSkill(params object[] args);
    }
}
