using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels.Characters.Contracts;
using ConsoleDiablo2.DataModels.Factories.Contracts;

using System;
using System.Linq;
using System.Reflection;

namespace ConsoleDiablo2.DataModels.Factories
{
    public class CharacterFactory : ICharacterFactory
    {
        //TODO: fix parameters
        public Character CreateCharacter(string type, string name)
        {
            var characterType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (characterType == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            if (!typeof(ICharacter).IsAssignableFrom(characterType))
            {
                throw new InvalidFilterCriteriaException(string.Format(ExceptionMessages.CharacterTypeIsNotACharacter, characterType));
            }

            var character = (Character)Activator.CreateInstance(characterType, name, false);

            return character;
        }
    }
}
