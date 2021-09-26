using System;
using System.Collections.Generic;

namespace ConsoleDiablo2.Common.SkillConstants
{
    public static class AmazonSkillConstants
    {
        //Inner Sight
        public const string InnerSightName = "Inner Sight";
        public const string InnerSightDescription = "[Passive] Increases your defense.";

        public const string InnerSightRequiredSkill = "None";
        public const string InnerSightRequiredSkillDesc = "Required Skill: ";

        public const string InnerSightRequiredLevelDesc = "Required Level: ";
        public const int InnerSightRequiredLevel = 1;

        public const string InnerSightDefenseValueDesc = "Defense per each skill level: +20%";
        public const double InnerSightDefenseValue = 1.2;

        public const string InnerSightFirstLevelValueDesc = "First level: Defense +500";
        public const int InnerSightFirstLevelValue = 500;

        public const string InnerSightTakesBonus = "Inner Sight takes bonus from the following skills:";
        public const string InnerSightTakesBonusFromDodge = "Dodge: +10% defense per each skill level";
        public const double InnerSightDodgeBonus = 1.1;

        public static List<string> innerSightDesc = new List<string>
        {
            InnerSightName,
            InnerSightDescription,
            String.Concat(InnerSightRequiredLevelDesc, InnerSightRequiredLevel),
            String.Concat(InnerSightRequiredSkillDesc, InnerSightRequiredSkill),
            InnerSightFirstLevelValueDesc,
            String.Concat(InnerSightDefenseValueDesc, InnerSightDefenseValue.ToString()),
            InnerSightTakesBonus,
            InnerSightTakesBonusFromDodge,
        };

        //Dodge
        public const string DodgeName = "Dodge";
        public const string DodgeDescription = "[Passive] Increases your chance to block.";

        public const string DodgeRequiredLevelDesc = "Required Level: ";
        public const int DodgeRequiredLevel = 10;

        public const string DodgeValueDesc = "Chance to block per each skill level: +3%";
        public const int DodgeValue = 3;

        public const string DodgeRequiredSkill = "Inner Sight";
        public const string DodgeRequiredSkillDesc = "Required Skill: ";

        public const string DodgeGetsBonusFrom = "Dodge gets bonus from the following skills:";
        public const string DodgeBonusFromInnerSight = "Inner Sight: +1% chance to block per each skill level";
        public const int DodgeInnerSightBonusValue = 1;

        public static List<string> dodgeDesc = new List<string>
        {
            DodgeName,
            String.Concat(DodgeRequiredLevelDesc, DodgeRequiredLevel),
            String.Concat(DodgeRequiredSkillDesc, DodgeRequiredSkill),
            DodgeDescription,
            DodgeValueDesc,
            DodgeGetsBonusFrom,
            DodgeBonusFromInnerSight
        };

        //Seduction
        public const string SeductionName = "Seduction";
        public const string SeductionDescription = "Seducing the enemy so that he is unwilling to attack you for one round and his defense is decreased.";

        public const string SeductionDefenseValueDesc = "Enemy defense per each skill level when active: -25%";
        public const double SeductionDefenseValue = 1.25;

        public const string SeductionFirstLevelValueDesc = "First level: Enemy defense -1000";
        public const int SeductionFirstLevelValue = 1000;

        public const string SeductionRequiredLevelDesc = "Required Level: ";
        public const int SeductionRequiredLevel = 18;

        public const string SeductionRequiredSkill = "Dodge";
        public const string SeductionRequiredSkillDesc = "Required Skill: ";

        public const string SeductionManaCostDesc = "Mana Cost: ";
        public const int SeductionManaCost = 120;

        public const string SeductionGetsBonusFrom = "Seduction gets bonus from the following skills:";
        public const string SeductionBonusFromDodge = "Dodge: -25% enemy defense per each skill level";
        public const double SeductionDodgeBonusValue = 1.25;

        public const string SeductionBonusFromInnerSight = "Inner Sight: -25% enemy defense per each skill level";
        public const double SeductionInnerSightBonusValue = 1.25;

        public static List<string> seductionDesc = new List<string>
        {
            SeductionName,
            String.Concat(SeductionRequiredLevelDesc, SeductionRequiredLevel),
            String.Concat(SeductionRequiredSkill, SeductionRequiredSkillDesc),
            SeductionDescription,
            SeductionFirstLevelValueDesc,
            String.Concat(SeductionDefenseValueDesc, SeductionDefenseValue.ToString()),
            String.Concat(SeductionManaCostDesc, SeductionManaCost.ToString()),
            SeductionBonusFromInnerSight,
            SeductionBonusFromDodge
        };

        //Power Strike
        public const string PowerStrikeName = "Power Strike";
        public const string PowerStrikeDescription = "A powerful attack.";

        public const string PowerStrikeRequiredSkill = "None";
        public const string PowerStrikeRequiredSkillDesc = "Required Skill: ";

        public const string PowerStrikeRequiredLevelDesc = "Required Level: ";
        public const int PowerStrikeRequiredLevel = 1;

        public const string PowerStrikeFirstLevelValueDesc = "First level: Damage +50";
        public const int PowerStrikeFirstLevelValue = 50;

        public const string PowerStrikeDamageDesc = "Damage per each skill level: +30%";
        public const double PowerStrikeDamageValue = 1.30;

        public const string PowerStrikeManaCostDesc = "Mana Cost: ";
        public const int PowerStrikeManaCost = 20;

        public const string PowerStrikeGetsBonusFrom = "Power Strike gets bonus from the following skills:";
        public const string PowerStrikeBonusFromChargedStrike = "Charged Strike: +10% damage per each skill level";
        public const double PowerStrikeChargedStrikeBonusValue = 1.1;

        public const string PowerStrikeBonusFromImpale = "Impale: +10% damage per each skill level";
        public const double PowerStrikeImpaleBonusValue = 1.1;

        public static List<string> powerStrikeDesc = new List<string>
        {
            PowerStrikeName,
            PowerStrikeDescription,
            String.Concat(PowerStrikeRequiredLevelDesc, PowerStrikeRequiredLevel),
            String.Concat(PowerStrikeRequiredSkillDesc, PowerStrikeRequiredSkill),
            PowerStrikeFirstLevelValueDesc,
            String.Concat(PowerStrikeDamageDesc, PowerStrikeDamageValue.ToString()),
            String.Concat(PowerStrikeManaCostDesc, PowerStrikeManaCost.ToString()),
            PowerStrikeBonusFromChargedStrike,
            PowerStrikeBonusFromImpale
        };

        //Charged Strike
        public const string ChargedStrikeName = "Charged Strike";
        public const string ChargedStrikeDescription = "Adds lightning damage to your power strike.";

        public const string ChargedStrikeRequiredLevelDesc = "Required Level: ";
        public const int ChargedStrikeRequiredLevel = 12;

        public const string ChargedStrikeRequiredSkill = "Power Strike";
        public const string ChargedStrikeRequiredSkillDesc = "Required Skill: ";

        public const string ChargedStrikeFirstLevelValueDesc = "First level: Lightning damage +400";
        public const int ChargedStrikeFirstLevelValue = 400;

        public const string ChargedStrikeDamageDesc = "Lightning damage per each skill level when active: + 25%";
        public const double ChargedStrikeDamageValue = 1.25;

        public const string ChargedStrikeManaCostDesc = "Mana Cost: ";
        public const int ChargedStrikeManaCost = 50;

        public const string ChargedStrikeGetsBonusFrom = "Charged Strike gets bonus from the following skills:";
        public const string ChargedStrikeBonusFromPowerStrike = "Power Strike: +10% damage per each skill level";
        public const double ChargedStrikePowerStrikeBonusValue = 1.1;

        public const string ChargedStrikeBonusFromImpale = "Impale: +10% damage per each skill level";
        public const double ChargedStrikeImpaleBonusValue = 1.1;

        public static List<string> chargedStrikeDesc = new List<string>
        {
            ChargedStrikeName,
            String.Concat(ChargedStrikeRequiredLevelDesc, ChargedStrikeRequiredLevel.ToString()),
            String.Concat(ChargedStrikeRequiredSkillDesc, ChargedStrikeRequiredSkill),
            ChargedStrikeDescription,
            ChargedStrikeFirstLevelValueDesc,
            String.Concat(ChargedStrikeDamageDesc, ChargedStrikeDamageValue.ToString()),
            String.Concat(ChargedStrikeManaCostDesc, ChargedStrikeManaCost.ToString())
        };

        //Impale
        public const string ImpaleName = "Impale";
        public const string ImpaleDescription = "A devastating attack that can be used only once during a fight and rapidly degrades your weapon for the next rounds.";

        public const string ImpaleRequiredSkill = "None";
        public const string ImpaleRequiredSkillDesc = "Required Skill: ";

        public const string ImpaleRequiredLevelDesc = "Required Level: ";
        public const int ImpaleRequiredLevel = 18;

        public const string ImpaleDamageValueDesc = "Physical damage per each skill level: +100%";
        public const int ImpaleDamageValue = 2;
        public const int ImpaleWeaponDamageDivider = 3;

        public const string ImpaleManaCostDesc = "Mana Cost: ";
        public const int ImpaleManaCost = 150;

        public static List<string> ImpaleDesc = new List<string>
        {
            ImpaleName,
            String.Concat(ImpaleRequiredSkillDesc, ImpaleRequiredSkill),
            String.Concat(ImpaleRequiredLevelDesc, ImpaleRequiredLevel.ToString()),
            ImpaleDescription,
            String.Concat(ImpaleDamageValueDesc, ImpaleDamageValue.ToString()),
            String.Concat(ImpaleManaCostDesc, ImpaleManaCost.ToString()),
            ChargedStrikeBonusFromPowerStrike,
            ChargedStrikeBonusFromImpale
        };

        //PoisonStrike
        public const string PoisonStrikeName = "PoisonStrike";
        public const string PoisonStrikeDescription = "Adds poison damage to your power strike.";

        public const string PoisonStrikeRequiredLevelDesc = "Required Level: ";
        public const int PoisonStrikeRequiredLevel = 12;

        public const string PoisonStrikeRequiredSkill = "Power Strike";
        public const string PoisonStrikeRequiredSkillDesc = "Required Skill: ";

        public const string PoisonStrikeFirstLevelValueDesc = "First level: Poison damage +100";
        public const int PoisonStrikeFirstLevelValue = 100;

        public const string PoisonStrikeDamageValueDesc = "Poison damage per each skill level: +20%";
        public const int PoisonStrikeDamageValue = 20;

        public const string PoisonStrikeManaCostDesc = "Mana Cost: ";
        public const int PoisonStrikeManaCost = 35;

        public const string PoisonStrikeGetsBonusFrom = "Poison Strike gets bonus from the following skills:";
        public const string PoisonStrikeBonusFromPowerStrike = "Power Strike: +5% damage per each skill level";
        public const double PoisonStrikePowerStrikeBonusValue = 1.05;

        public const string PoisonStrikeBonusFromPlagueStrike = "Plague Strike: +10% damage per each skill level";
        public const double PoisonStrikePlagueStrikeBonusValue = 1.1;

        public static List<string> poisonStrikeDesc = new List<string>
        {
            PoisonStrikeName,
            String.Concat(PoisonStrikeRequiredLevelDesc, PoisonStrikeRequiredLevel.ToString()),
            String.Concat(PoisonStrikeRequiredSkillDesc, PoisonStrikeRequiredSkill),
            PoisonStrikeDescription,
            PoisonStrikeFirstLevelValueDesc,
            String.Concat(PoisonStrikeDamageValueDesc, PoisonStrikeDamageValue.ToString()),
            String.Concat(PoisonStrikeManaCostDesc, PoisonStrikeManaCost.ToString()),
            PoisonStrikeGetsBonusFrom,
            PoisonStrikeBonusFromPowerStrike,
            PoisonStrikeBonusFromPlagueStrike
        };

        //PlagueStrike
        public const string PlagueStrikeName = "Plague Strike";
        public const string PlagueStrikeDescription = "A powerful attack equipped with deadly poison that may last for several rounds.";

        public const string PlagueStrikeRequiredLevelDesc = "Required Level: ";
        public const int PlagueStrikeRequiredLevel = 18;

        public const string PlagueStrikeRequiredSkill = "Poison Strike";
        public const string PlagueStrikeRequiredSkillDesc = "Required Skill: ";

        public const string PlagueStrikeFirstLevelValueDesc = "First level: Poison damage +350";
        public const int PlagueStrikeFirstLevelValue = 350;

        public const string PlagueStrikeDamageValueDesc = "First level: Poison damage: +25%";
        public const double PlagueStrikeDamageValue = 1.25;

        public const string PlagueStrikeRoundDurationDesc = "Poison length per each level: +0.25 rounds";
        public const double PlagueStrikeRoundsPerLevel = 0.25;

        public const string PlagueStrikeManaCostDesc = "Mana Cost: ";
        public const int PlagueStrikeManaCost = 65;

        public const string PlagueStrikeGetsBonusFrom = "Plague Strike gets bonus from the following skills:";
        public const string PlagueStrikeBonusFromPowerStrike = "Power Strike: +5% damage per each skill level";
        public const double PlagueStrikePowerStrikeBonusValue = 1.05;

        public const string PlagueStrikeBonusFromPoisonStrike = "Poison Strike: +10% damage per each skill level";
        public const double PlagueStrikePoisonStrikeBonusValue = 1.1;

        public static List<string> PlagueStrikeDesc = new List<string>
        {
            PlagueStrikeName,
            String.Concat(PlagueStrikeRequiredLevelDesc, PlagueStrikeRequiredLevel.ToString()),
            String.Concat(PlagueStrikeRequiredSkillDesc, PlagueStrikeRequiredSkill),
            PlagueStrikeDescription,
            String.Concat(PlagueStrikeDamageValueDesc, PlagueStrikeDamageValue.ToString()),
            String.Concat(PlagueStrikeManaCostDesc, PlagueStrikeManaCost.ToString()),
            PlagueStrikeGetsBonusFrom,
            PlagueStrikeBonusFromPowerStrike,
            PlagueStrikeBonusFromPoisonStrike
        };

        //Spear Mastery
        public const string SpearMasteryName = "Spear Mastery";
        public const string SpearMasteryDescription = "[Passive] Develops your spear-fighting skills.";

        public const string SpearMasteryRequiredSkill = "None";
        public const string SpearMasteryRequiredSkillDesc = "Required Skill: ";

        public const string SpearMasteryRequiredLevelDesc = "Required Level: ";
        public const int SpearMasteryRequiredLevel = 1;

        public const string SpearMasteryDamageValueDesc = "Physical damage per each skill level when fighting with a spear: +25% of your spear's damage";
        public const double SpearMasteryDamageValue = 0.25;

        public static List<string> spearMasteryDesc = new List<string>
        {
            SpearMasteryName,
            SpearMasteryDescription,
            SpearMasteryDamageValueDesc,
            String.Concat(SpearMasteryRequiredSkillDesc, SpearMasteryRequiredSkill),
            String.Concat(SpearMasteryRequiredLevelDesc, SpearMasteryRequiredLevel.ToString()),
        };

        //Critical Strike
        public const string CriticalStrikeName = "Critical Strike";
        public const string CriticalStrikeDescription = "[Passive] Increases your chance of critical hit.";

        public const string CriticalStrikeRequiredLevelDesc = "Required Level: 12";
        public const int CriticalStrikeRequiredLevel = 12;

        public const string CriticalStrikeRequiredSkill = "Spear Mastery";
        public const string CriticalStrikeRequiredSkillDesc = "Required Skill: ";

        public const string CriticalStrikeValueDesc = "Chance of critical hit per each skill level: +3%";
        public const int CriticalStrikeValue = 3;

        public static List<string> criticalStrikeDesc = new List<string>
        {
            CriticalStrikeName,
            String.Concat(CriticalStrikeRequiredLevelDesc, CriticalStrikeRequiredLevel.ToString()),
            String.Concat(CriticalStrikeRequiredSkillDesc, CriticalStrikeRequiredSkill),
            CriticalStrikeDescription,
            String.Concat(CriticalStrikeValueDesc, CriticalStrikeValue.ToString()),
        };

        //Passive Mastery
        public const string PassiveMasteryName = "Passive Mastery";
        public const string PassiveMasteryDescription = "[Passive] Increases the skill level of each one of your developed passive skills.";

        public const string PassiveMasteryRequiredLevelDesc = "Required Level: 12";
        public const int PassiveMasteryRequiredLevel = 12;

        public const string PassiveMasteryRequiredSkill = "None";
        public const string PassiveMasteryRequiredSkillDesc = "Required Skill: ";

        public const string PassiveMasteryValueDesc = "+1 to each developed passive skill per level";
        public const int PassiveMasteryValue = 1;

        public static List<string> passiveMasteryDesc = new List<string>
        {
            PassiveMasteryName,
            String.Concat(PassiveMasteryRequiredSkillDesc, PassiveMasteryRequiredSkill),
            String.Concat(PassiveMasteryRequiredLevelDesc, PassiveMasteryRequiredLevel.ToString()),
            PassiveMasteryDescription,
            String.Concat(PassiveMasteryValueDesc, PassiveMasteryValue.ToString()),
        };

        //Valkyrism
        public const string ValkyrismName = "Valkyrism";
        public const string ValkyrismDescription = "[Passive] Increases the skill level of each one of your developed non-passive skills.";

        public const string ValkyrismRequiredLevelDesc = "Required Level: 18";
        public const int ValkyrismRequiredLevel = 18;

        public const string ValkyrismRequiredSkill = "None";
        public const string ValkyrismRequiredSkillDesc = "Required Skill: ";

        public const string ValkyrismValueDesc = "+1 to each developed non-passive skill per level";
        public const int ValkyrismValue = 1;

        public static List<string> valkyrismDesc = new List<string>
        {
            ValkyrismName,
            String.Concat(ValkyrismRequiredSkillDesc, ValkyrismRequiredSkill),
            String.Concat(ValkyrismRequiredLevelDesc, ValkyrismRequiredLevel.ToString()),
            ValkyrismDescription,
            String.Concat(ValkyrismValueDesc, ValkyrismValue.ToString()),
        };
    }
}
