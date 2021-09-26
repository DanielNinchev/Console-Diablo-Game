using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels.Factories.Contracts;
using ConsoleDiablo2.DataModels.Skills.Contracts;

using System;
using System.Linq;
using System.Reflection;

namespace ConsoleDiablo2.DataModels.Factories
{
    public class SkillFactory : ISkillFactory
    {
        public Skill CreateSkill(string type)
        {
            var skillType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(it => it.Name == string.Join("", type.Split()));

            if (skillType == null)
            {
                throw new ArgumentNullException(ExceptionMessages.SkillDoesNotExist);
            }

            if (!typeof(ISkill).IsAssignableFrom(skillType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ThisIsNotASkill));
            }

            var skill = (Skill)Activator.CreateInstance(skillType);

            return skill;
        }
    }
}
