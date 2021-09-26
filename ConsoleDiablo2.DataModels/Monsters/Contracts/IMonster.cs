using ConsoleDiablo2.DataModels.Enums;

namespace ConsoleDiablo2.DataModels.Monsters.Contracts
{
    public interface IMonster : IBeing
    {
        MonsterRank Type { get; set; }

        int Mana { get; set; }

        int ManaCostForAbility { get; set; }

        byte DroppingIndex { get; set; }

        void Attack(Character character);

        void UnaffectCharacter(Character character);

        void UseSpecialAbility(Character character);
    }
}
