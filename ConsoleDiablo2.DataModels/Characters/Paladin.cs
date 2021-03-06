using ConsoleDiablo2.Common;

using System;
using System.Collections.Generic;

namespace ConsoleDiablo2.DataModels.Characters
{
    public class Paladin : Character
    {
        public Paladin(string name, bool isDeleted)
            : base(name, isDeleted,
                  damage: CharacterConstants.PaladinDamage,
                  baseLife: CharacterConstants.PaladinBaseLife,
                  baseMana: CharacterConstants.PaladinBaseMana)
        {
        }

        //public Paladin(int id,
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
