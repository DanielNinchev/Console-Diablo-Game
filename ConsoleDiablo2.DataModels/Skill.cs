using ConsoleDiablo2.Common;
using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Skills.Contracts;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleDiablo2.DataModels
{
    public abstract class Skill : ISkill
    {
        public Skill()
        {
            this.Level = 0;
            this.RequiredLevel = 1;
            this.IsDeveloped = false;
            this.IsActivated = false;
            this.IsPassive = false;
            this.RequiredSkill = SkillDescriptions.NoRequiredSkill;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public List<string> Description { get; set; }

        public int Level { get; set; }

        public double? ManaCost { get; set; }

        public int RequiredLevel { get; set; }

        public string RequiredSkill { get; set; }

        public bool IsDeveloped { get; set; }

        public bool IsActivated { get; set; }

        public bool IsPassive { get; set; }

        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public abstract void AffectCharacter(Character character);

        public void CheckCharacterMana(Character character)
        {
            if (this.ManaCost > character.Mana)
            {
                this.IsActivated = false;

                throw new ArgumentException(ExceptionMessages.NotEnoughManaMessage);
            }
            else
            {
                character.Mana -= (int)this.ManaCost;
            }
        }

        public List<string> InitializeSkillDescription(List<List<string>> skillDescriptions)
        {
            List<string> skillDescription = new List<string>();

            foreach (var listOfDescriptions in skillDescriptions)
            {
                if (listOfDescriptions.Contains(this.Name))
                {
                    for (int i = 0; i < listOfDescriptions.Count; i++)
                    {
                        skillDescription.Add(listOfDescriptions[i]);
                    }
                }
            }

            return skillDescription;
        }

        public abstract void UnaffectCharacter(Character character);
    }
}
