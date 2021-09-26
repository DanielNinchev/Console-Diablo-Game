using ConsoleDiablo2.DataModels;

namespace ConsoleDiablo2.Services.Contracts
{
    public interface IMonsterService
    {
        void AttackCharacter(int characterId, Monster monster);

        Monster CreateMonster(int characterId);

        string DrawMonsterType();

        void FightMonster(int characterId, Monster monster, Skill skill);

        bool SufferAttack(int characterId, Monster monster, Skill skill);
    }
}
