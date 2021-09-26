namespace ConsoleDiablo2.DataModels.Skills.Contracts
{
    public interface IEnemyAffectingSkill : ISkill
    {
        void AffectEnemy(Being enemy);
        void UnaffectEnemy(Being enemy);
    }
}
