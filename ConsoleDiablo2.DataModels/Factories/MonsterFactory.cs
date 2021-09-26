using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels.Factories.Contracts;
using ConsoleDiablo2.DataModels.Monsters.Contracts;

using System;
using System.Linq;
using System.Reflection;

namespace ConsoleDiablo2.DataModels.Factories
{
    public class MonsterFactory : IMonsterFactory
    {
        public Monster CreateMonster(string type, Character character)
        {
            var typeOfMonster = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(it => it.Name == type);

            if (typeOfMonster == null)
            {
                throw new ArgumentNullException(ExceptionMessages.NoSuchMonsterTypeMessage);
            }

            if (!typeof(IMonster).IsAssignableFrom(typeOfMonster))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ThisIsNotAMonster));
            }

            var monster = (Monster)Activator.CreateInstance(typeOfMonster, character);

            return monster;
        }
    }
}
