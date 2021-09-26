using ConsoleDiablo2.DataModels.Enums;

namespace ConsoleDiablo2.DataModels.Factories.Contracts
{
    public interface IMonsterFactory
    {
        Monster CreateMonster(string type, Character character);
    }
}
