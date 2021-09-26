namespace ConsoleDiablo2.DataModels.Factories.Contracts
{
    public interface ICharacterFactory
    {
        Character CreateCharacter(string type, string name);
    }
}
