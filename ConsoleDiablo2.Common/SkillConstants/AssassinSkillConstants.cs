using System;
using System.Collections.Generic;

namespace ConsoleDiablo2.Common.SkillConstants
{
    public static class AssassinSkillConstants
    {
        //Weapon Block
        public const string WeaponBlockName = "Weapon Block";
        public const string WeaponBlockDescription = "[Passive] Increases your chance to block for each weapon in your hand.";

        public const string WeaponBlockRequiredLevelDesc = "Required Level: ";
        public const int WeaponBlockRequiredLevel = 6;

        public const string WeaponBlockValueDesc = "Chance to block for each weapon in hand per skill level: + 2%";
        public const int WeaponBlockValue = 2;

        public const string WeaponBlockRequiredSkill = "None";
        public const string WeaponBlockRequiredSkillDesc = "Required Skill: ";

        public static List<string> weaponBlockDesc = new List<string>
        {
            WeaponBlockName,
            WeaponBlockDescription,
            WeaponBlockValueDesc,
            String.Concat(WeaponBlockRequiredSkillDesc, WeaponBlockRequiredSkill),
            String.Concat(WeaponBlockRequiredLevelDesc, WeaponBlockRequiredLevel),
        };

        //Martial Arts
        public const string MartialArtsName = "Martial Arts";
        public const string MartialArtsDescription = "[Passive] Develops your martial arts.";

        public const string MartialArtsRequiredLevelDesc = "Required Level: ";
        public const int MartialArtsRequiredLevel = 1;

        public const string MartialArtsValueDesc = "+ 1 to each developed Martial Art (Headshot Kick, Devastation, Assassination) skill per Martial Arts skill level";
        public const int MartialArtsValue = 1;

        public const string MartialArtsRequiredSkill = "None";
        public const string MartialArtsRequiredSkillDesc = "Required Skill: ";

        public static List<string> martialArtsDesc = new List<string>
        {
            MartialArtsName,
            MartialArtsDescription,
            MartialArtsValueDesc,
            String.Concat(MartialArtsRequiredSkillDesc, MartialArtsRequiredSkill),
            String.Concat(MartialArtsRequiredLevelDesc, MartialArtsRequiredLevel),
        };

        //Venom
        public const string VenomName = "Venom";
        public const string VenomDescription = "[Passive] Adds poison damage to all your Martial Arts attacks.";

        public const string VenomRequiredLevelDesc = "Required Level: ";
        public const int VenomRequiredLevel = 12;

        public const string VenomValueDesc = "Poison damage to each developed martial art per skill level: + 10%";
        public const double VenomValue = 1.10;

        public const string VenomRequiredSkill = "Martial Arts";
        public const string VenomRequiredSkillDesc = "Required Skill: ";

        public static List<string> venomDesc = new List<string>
        {
            VenomName,
            VenomDescription,
            VenomValueDesc,
            String.Concat(VenomRequiredSkillDesc, VenomRequiredSkill),
            String.Concat(VenomRequiredLevelDesc, VenomRequiredLevel),
        };

        //Dagger Mastery
        public const string DaggerMasteryName = "Dagger Mastery";
        public const string DaggerMasteryDescription = "[Passive] Develops your dagger-fighting skills.";

        public const string DaggerMasteryRequiredLevelDesc = "Required Level: ";
        public const int DaggerMasteryRequiredLevel = 1;

        public const string DaggerMasteryValueDesc = "Physical damage per each skill level when fighting with a dagger: +30% of your dagger's damage";
        public const double DaggerMasteryValue = 0.3;

        public const string DaggerMasteryRequiredSkill = "None";
        public const string DaggerMasteryRequiredSkillDesc = "Required Skill: ";

        public static List<string> daggerMasteryDesc = new List<string>
        {
            DaggerMasteryName,
            DaggerMasteryDescription,
            DaggerMasteryValueDesc,
            String.Concat(DaggerMasteryRequiredSkillDesc, DaggerMasteryRequiredSkill),
            String.Concat(DaggerMasteryRequiredLevelDesc, DaggerMasteryRequiredLevel),
        };

        //Shock Web
        public const string ShockWebName = "Shock Web";
        public const string ShockWebDescription = "Throws a device that creates a web of lightning around the enemy.";

        public const string ShockWebFirstLevelValueDesc = "First level: Damage +35";
        public const int ShockWebFirstLevelValue = 35;

        public const string ShockWebDamageValueDesc = "Lightning damage: +15%";
        public const double ShockWebDamageValue = 1.15;

        public const string ShockWebManaCostDesc = "Mana Cost: ";
        public const int ShockWebManaCost = 10;

        public const string ShockWebGetsBonusFrom = "Shock Web gets bonus from the following skills:";
        public const string ShockWebBonusFromLightningSentry = "Lightning Sentry: +10% lightning damage per each skill level";
        public const double ShockWebLightningSentryBonusValue = 1.1;

        public const string ShockWebBonusFromDeathSentry = "Death Sentry: +12% lightning damage per each skill level";
        public const double ShockWebDeathSentryBonusValue = 1.12;

        public const string ShockWebRequiredSkill = "None";
        public const string ShockWebRequiredSkillDesc = "Required Skill: ";

        public const string ShockWebRequiredLevelDesc = "Required Level: ";
        public const int ShockWebRequiredLevel = 1;

        public static List<string> shockWebDesc = new List<string>
        {
            ShockWebName,
            ShockWebDescription,
            ShockWebFirstLevelValueDesc,
            ShockWebDamageValueDesc,
            String.Concat(ShockWebManaCostDesc, ShockWebManaCost.ToString()),
            ShockWebGetsBonusFrom,
            ShockWebBonusFromLightningSentry,
            ShockWebBonusFromDeathSentry,
            String.Concat(ShockWebRequiredSkillDesc, ShockWebRequiredSkill),
            String.Concat(ShockWebRequiredLevelDesc, ShockWebRequiredLevel),
        };

        //Lightning Sentry
        public const string LightningSentryName = "Lightning Sentry";
        public const string LightningSentryDescription = "Installs a device in front of the enemy that projects lightning and drains enemy's mana.";

        public const string LightningSentryFirstLevelValueDesc = "First level: Damage +120";
        public const int LightningSentryFirstLevelValue = 120;

        public const string LightningSentryDamageValueDesc = "Lightning damage: +20%";
        public const double LightningSentryDamageValue = 1.20;

        public const string LightningSentryManaDrainageValueDesc = "Enemy's mana taken per hit: -2% from enemy's mana per skill level";
        public const double LightningSentryManaDrainageValue = 1.02;

        public const string LightningSentryManaCostDesc = "Mana Cost: ";
        public const int LightningSentryManaCost = 45;

        public const string LightningSentryGetsBonusFrom = "Lightning Sentry gets bonus from the following skills:";
        public const string LightningSentryBonusFromShockWeb = "Shock Web: +10% lightning damage per each skill level";
        public const double LightningSentryShockWebBonusValue = 1.1;

        public const string LightningSentryBonusFromDeathSentry = "Death Sentry: +12% lightning damage per each skill level";
        public const double LightningSentryDeathSentryBonusValue = 1.12;

        public const string LightningSentryRequiredSkill = "Shock Web";
        public const string LightningSentryRequiredSkillDesc = "Required Skill: ";

        public const string LightningSentryRequiredLevelDesc = "Required Level: ";
        public const int LightningSentryRequiredLevel = 10;

        public static List<string> lightningSentryDesc = new List<string>
        {
            LightningSentryName,
            LightningSentryDescription,
            LightningSentryFirstLevelValueDesc,
            LightningSentryDamageValueDesc,
            String.Concat(LightningSentryManaCostDesc, LightningSentryManaCost.ToString()),
            LightningSentryGetsBonusFrom,
            LightningSentryBonusFromShockWeb,
            LightningSentryBonusFromDeathSentry,
            String.Concat(LightningSentryRequiredSkillDesc, LightningSentryRequiredSkill),
            String.Concat(LightningSentryRequiredLevelDesc, LightningSentryRequiredLevel),
        };

        //Death Sentry
        public const string DeathSentryName = "Death Sentry";
        public const string DeathSentryDescription = "Installs a device in front of the enemy that projects lightning and lowers enemy's lightning resistance.";

        public const string DeathSentryFirstLevelValueDesc = "First level: Damage +250";
        public const int DeathSentryFirstLevelValue = 250;

        public const string DeathSentryDamageValueDesc = "Lightning damage: +20%";
        public const double DeathSentryDamageValue = 1.20;

        public const string DeathSentryManaDrainageValueDesc = "Enemy's lightning resistance taken: -2% per skill level";
        public const double DeathSentryManaDrainageValue = 2;

        public const string DeathSentryManaCostDesc = "Mana Cost: ";
        public const int DeathSentryManaCost = 80;

        public const string DeathSentryGetsBonusFrom = "Death Sentry gets bonus from the following skills:";
        public const string DeathSentryBonusFromShockWeb = "Shock Web: +10% lightning damage per each skill level";
        public const double DeathSentryShockWebBonusValue = 1.1;

        public const string DeathSentryBonusFromLightningSentry = "Lightning Sentry: +12% lightning damage per each skill level";
        public const double DeathSentryLightningSentryBonusValue = 1.12;

        public const string DeathSentryRequiredSkill = "Lightning Sentry";
        public const string DeathSentryRequiredSkillDesc = "Required Skill: ";

        public const string DeathSentryRequiredLevelDesc = "Required Level: ";
        public const int DeathSentryRequiredLevel = 18;

        public static List<string> deathSentryDesc = new List<string>
        {
            DeathSentryName,
            DeathSentryDescription,
            DeathSentryFirstLevelValueDesc,
            DeathSentryDamageValueDesc,
            String.Concat(DeathSentryManaCostDesc, DeathSentryManaCost.ToString()),
            DeathSentryGetsBonusFrom,
            DeathSentryBonusFromShockWeb,
            DeathSentryBonusFromLightningSentry,
            String.Concat(DeathSentryRequiredSkillDesc, DeathSentryRequiredSkill),
            String.Concat(DeathSentryRequiredLevelDesc, DeathSentryRequiredLevel),
        };

        //Fire Dagger
        public const string FireDaggerName = "Fire Dagger";
        public const string FireDaggerDescription = "Enchants each dagger you hold in your hands with fire damage";

        public const string FireDaggerFirstLevelValueDesc = "First level: Damage +55";
        public const int FireDaggerFirstLevelValue = 55;

        public const string FireDaggerDamageValueDesc = "Fire damage: +20%";
        public const double FireDaggerDamageValue = 1.20;

        public const string FireDaggerManaCostDesc = "Mana Cost: ";
        public const int FireDaggerManaCost = 50;

        public const string FireDaggerGetsBonusFrom = "Fire Dagger gets bonus from the following skills:";
        public const string FireDaggerBonusFromShockWeb = "Shock Web: +10% fire damage per each skill level";
        public const double FireDaggerShockWebBonusValue = 1.1;

        public const string FireDaggerBonusFromExplosiveDagger = "Explosive Dagger: +12% fire damage per each skill level";
        public const double FireDaggerExplosiveDaggerBonusValue = 1.12;

        public const string FireDaggerRequiredSkill = "Shock Web";
        public const string FireDaggerRequiredSkillDesc = "Required Skill: ";

        public const string FireDaggerRequiredLevelDesc = "Required Level: ";
        public const int FireDaggerRequiredLevel = 6;

        public static List<string> fireDaggerDesc = new List<string>
        {
            FireDaggerName,
            FireDaggerDescription,
            FireDaggerFirstLevelValueDesc,
            FireDaggerDamageValueDesc,
            String.Concat(FireDaggerManaCostDesc, FireDaggerManaCost.ToString()),
            FireDaggerGetsBonusFrom,
            FireDaggerBonusFromShockWeb,
            FireDaggerBonusFromExplosiveDagger,
            String.Concat(FireDaggerRequiredSkillDesc, FireDaggerRequiredSkill),
            String.Concat(FireDaggerRequiredLevelDesc, FireDaggerRequiredLevel),
        };

        //Explosive Dagger
        public const string ExplosiveDaggerName = "Explosive Dagger";
        public const string ExplosiveDaggerDescription = "Enchants each dagger you hold in your hands with explosive fire damage and decreases enemy's fire resistance";

        public const string ExplosiveDaggerFirstLevelValueDesc = "First level: Damage +320";
        public const int ExplosiveDaggerFirstLevelValue = 320;

        public const string ExplosiveDaggerDamageValueDesc = "Fire damage: +20%";
        public const double ExplosiveDaggerDamageValue = 1.20;

        public const string ExplosiveDaggerFireResDrainageValueDesc = "Enemy's fire resistance taken: -2% per skill level";
        public const int ExplosiveDaggerFireResDrainageValue = 2;

        public const string ExplosiveDaggerManaCostDesc = "Mana Cost: ";
        public const int ExplosiveDaggerManaCost = 120;

        public const string ExplosiveDaggerGetsBonusFrom = "Explosive Dagger gets bonus from the following skills:";
        public const string ExplosiveDaggerBonusFromShockWeb = "Shock Web: +10% fire damage per each skill level";
        public const double ExplosiveDaggerShockWebBonusValue = 1.1;

        public const string ExplosiveDaggerBonusFromFireDagger = "Fire Dagger: +12% fire damage per each skill level";
        public const double ExplosiveDaggerFireDaggerBonusValue = 1.12;

        public const string ExplosiveDaggerRequiredSkill = "Fire Dagger";
        public const string ExplosiveDaggerRequiredSkillDesc = "Required Skill: ";

        public const string ExplosiveDaggerRequiredLevelDesc = "Required Level: ";
        public const int ExplosiveDaggerRequiredLevel = 14;

        public static List<string> explosiveDaggerDesc = new List<string>
        {
            ExplosiveDaggerName,
            ExplosiveDaggerDescription,
            ExplosiveDaggerFirstLevelValueDesc,
            ExplosiveDaggerDamageValueDesc,
            ExplosiveDaggerFireResDrainageValueDesc,
            String.Concat(ExplosiveDaggerManaCostDesc, ExplosiveDaggerManaCost.ToString()),
            ExplosiveDaggerGetsBonusFrom,
            ExplosiveDaggerBonusFromShockWeb,
            ExplosiveDaggerBonusFromFireDagger,
            String.Concat(ExplosiveDaggerRequiredSkillDesc, ExplosiveDaggerRequiredSkill),
            String.Concat(ExplosiveDaggerRequiredLevelDesc, ExplosiveDaggerRequiredLevel),
        };

        //Headshot Kick
        public const string HeadshotKickName = "Headshot Kick";
        public const string HeadshotKickDescription = "[Martial Art] A powerful kick in the head of the enemy";

        public const string HeadshotKickFirstLevelValueDesc = "First level: Damage +50";
        public const int HeadshotKickFirstLevelValue = 50;

        public const string HeadshotKickDamageValueDesc = "Physical damage: +15%";
        public const double HeadshotKickDamageValue = 1.15;

        public const string HeadshotKickManaCostDesc = "Mana Cost: ";
        public const int HeadshotKickManaCost = 20;

        public const string HeadshotKickGetsBonusFrom = "Headshot Kick gets bonus from the following skills:";
        public const string HeadshotKickBonusFromDevastation= "Devastation: +10% physical damage per each skill level";
        public const double HeadshotKickDevastationBonusValue = 1.1;

        public const string HeadshotKickBonusFromAssassination = "Assassination: +12% physical damage per each skill level";
        public const double HeadshotKickAssassinationBonusValue = 1.12;

        public const string HeadshotKickRequiredSkill = "None";
        public const string HeadshotKickRequiredSkillDesc = "Required Skill: ";

        public const string HeadshotKickRequiredLevelDesc = "Required Level: ";
        public const int HeadshotKickRequiredLevel = 1;

        public static List<string> headshotKickDesc = new List<string>
        {
            HeadshotKickName,
            HeadshotKickDescription,
            HeadshotKickFirstLevelValueDesc,
            HeadshotKickDamageValueDesc,
            String.Concat(HeadshotKickManaCostDesc, HeadshotKickManaCost.ToString()),
            HeadshotKickGetsBonusFrom,
            HeadshotKickBonusFromDevastation,
            HeadshotKickBonusFromAssassination,
            String.Concat(HeadshotKickRequiredSkillDesc, HeadshotKickRequiredSkill),
            String.Concat(HeadshotKickRequiredLevelDesc, HeadshotKickRequiredLevel),
        };

        //Devastation
        public const string DevastationName = "Devastation";
        public const string DevastationDescription = "[Martial Art] A risky attack that has a chance of eliminating half of the enemy's BASE LIFE points but burns half of your mana";

        public const string DevastationDamageValueDesc = "Enemy's life: -50% of his base life points";
        public const double DevastationEnemyLifeDivider = 0.5;

        public const string DevastationValueDesc = "Chance of devastation: +10% per skill level";
        public const double DevastationValue = 10;

        public const string DevastationRequiredSkill = "Headshot Kick";
        public const string DevastationRequiredSkillDesc = "Required Skill: ";

        public const string DevastationRequiredLevelDesc = "Required Level: ";
        public const int DevastationRequiredLevel = 12;

        public static List<string> devastationDesc = new List<string>
        {
            DevastationName,
            DevastationDescription,
            DevastationDamageValueDesc,
            DevastationValueDesc,
            String.Concat(DevastationRequiredSkillDesc, DevastationRequiredSkill),
            String.Concat(DevastationRequiredLevelDesc, DevastationRequiredLevel),
        };

        //Assassination
        public const string AssassinationName = "Assassination";
        public const string AssassinationDescription = "[Martial Art] A risky attack that has a chance of annihilating the enemy with one strike but burns half of your mana";

        public const string AssassinationValueDesc = "Chance of assassination: +5%";
        public const double AssassinationValue = 5;

        public const string AssassinationManaCostDesc = "Mana Cost: Half";

        public const string AssassinationRequiredSkill = "Devastation";
        public const string AssassinationRequiredSkillDesc = "Required Skill: ";

        public const string AssassinationRequiredLevelDesc = "Required Level: ";
        public const int AssassinationRequiredLevel = 18;

        public static List<string> assassinationDesc = new List<string>
        {
            AssassinationName,
            AssassinationDescription,
            AssassinationValueDesc,
            AssassinationManaCostDesc,
            String.Concat(AssassinationRequiredSkillDesc, AssassinationRequiredSkill),
            String.Concat(AssassinationRequiredLevelDesc, AssassinationRequiredLevel),
        };
    }
}
