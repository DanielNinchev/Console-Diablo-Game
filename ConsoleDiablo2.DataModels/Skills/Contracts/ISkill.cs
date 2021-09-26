using System.Collections.Generic;

namespace ConsoleDiablo2.DataModels.Skills.Contracts
{
    public interface ISkill
    {
        int Id { get; set; }

        string Name { get; set; }
        
        List<string> Description { get; set; }

        int Level { get; set; }

        int RequiredLevel { get; set; }

        string RequiredSkill { get; set; }

        bool IsDeveloped { get; set; }

        bool IsActivated { get; set; }

        double? ManaCost { get; set; }

        void AffectCharacter(Character character);

        List<string> InitializeSkillDescription(List<List<string>> skillDescriptions);

        void UnaffectCharacter(Character character);
    }
}
