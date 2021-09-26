namespace ConsoleDiablo2.Common
{
    public static class CharacterConstants
    {
        //Character

        public const double LifeRegenerator = 0.001;
        public const double ManaRegenerator = 0.001;

        public const string StrengthStatName = "Strength";
        public const string DexterityStatName = "Dexterity";
        public const string VitalityStatName = "Vitality";
        public const string EnergyStatName = "Energy";

        public const double StrengthStatMultiplier = 1.2;
        public const int DexterityChanceToBlockValue = 3;
        public const int DexterityChanceOfCriticalHitValue = 1;
        public const int DexterityDefenseValue = 200;
        public const double VitalityLifeMultiplier = 1.3;
        public const double EnergyManaMultiplier = 1.4;


        public const string CharacterStringFightViewFormat = "{0}\n" +
            "[{1}]\n" +
            "Level: {2}\n" +
            "Life: {3}/{4}\n" +
            "Mana: {5}/{6}\n" +
            "Damage: {7}\n" +
            "Chance of Critical Hit: {8}\n" +
            "Defense: {9}\n" +
            "Fire Resistance: {10}\n" +
            "Lightning Resistance: {11}\n" +
            "Cold Resistance: {12}\n" +
            "Poison Resistance: {13}\n";

        public const string CharacterStringLobbyViewFormat = "Level: {0}\n" +
            "Experience: {1}\n" +
            "Life: {2}\n" +
            "Mana: {3}\n" +
            "Physical Damage: {4}\n" +
            "Chance of Critical Hit: {5}\n"+
            "Defense: {6}\n" +
            "Fire Resistance: {7}\n" +
            "Lightning Resistance: {8}\n" +
            "Cold Resistance: {9}\n" +
            "Poison Resistance: {10}\n" +
            "Gold Coins: {11}";

        //Amazon
        public const int AmazonDamage = 15;
        public const int AmazonBaseLife = 100;
        public const int AmazonBaseMana = 20;

        //Assassin
        public const int AssassinDamage = 10;
        public const int AssassinBaseLife = 100;
        public const int AssassinBaseMana = 25;

        //Barbarian
        public const int BarbarianDamage = 15;
        public const int BarbarianBaseLife = 110;
        public const int BarbarianBaseMana = 10;

        //Druid
        public const int DruidDamage = 5;
        public const int DruidBaseLife = 25;
        public const int DruidBaseMana = 30;

        //Necromancer
        public const int NecromancerDamage = 2;
        public const int NecromancerBaseLife = 25;
        public const int NecromancerBaseMana = 35;

        //Paladin
        public const int PaladinDamage = 15;
        public const int PaladinBaseLife = 100;
        public const int PaladinBaseMana = 20;

        //Sorceress
        public const int SorceressDamage = 5;
        public const int SorceressBaseLife = 90;
        public const int SorceressBaseMana = 40;
    }
}
