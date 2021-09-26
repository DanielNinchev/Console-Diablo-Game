using System.Collections.Generic;

namespace ConsoleDiablo2.DataModels.Skills.Contracts
{
    public interface IBarbarianSkill : ISkill
    {
        List<string> InitializeBarbarianSkillDescription();
    }
}
