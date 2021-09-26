﻿using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels.SkillTrees;

namespace ConsoleDiablo2.DataModels.Characters
{
    public class Assassin : Character
    {
        public Assassin(string name, bool isDeleted)
            : base(name, isDeleted,
                  damage: CharacterConstants.AssassinDamage,
                  baseLife: CharacterConstants.AssassinBaseLife,
                  baseMana: CharacterConstants.AssassinBaseMana)
        {
            this.SkillTree = AssassinSkillTree.InitializeAssassinSkills();
        }

        //public Assassin(int id,
        //    string name,
        //    double exp,
        //    bool isDeleted,
        //    DateTime dateCreated,
        //    int damage,
        //    int defense,
        //    int baseLife,
        //    int baseMana,
        //    int fireRes,
        //    int lightRes,
        //    int coldRes,
        //    int poisonRes,
        //    int goldCoins,
        //    Account account,
        //    Gear gear,
        //    Inventory inventory,
        //    ICollection<Skill> skills) : base(id,
        //                            name,
        //                            exp,
        //                            isDeleted,
        //                            dateCreated,
        //                            damage,
        //                            defense,
        //                            baseLife,
        //                            baseMana,
        //                            fireRes,
        //                            lightRes,
        //                            coldRes,
        //                            poisonRes,
        //                            goldCoins,
        //                            account,
        //                            gear,
        //                            inventory,
        //                            skills)
        //{

        //}
    }
}
