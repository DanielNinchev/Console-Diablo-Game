namespace ConsoleDiablo2.Common
{
    public static class GlobalConstants
    {
        //Account
        public const int AccountNameMinLength = 3;
        public const int AccountNameMaxLength = 16;
        public const int PasswordMinLength = 3;
        public const int PasswordMaxLength = 16;

        //Being
        public const int MaxResistanceValue = 100;
        public const int DefenseDivider = 5;
        public const double ResistanceDivider = 100;
        public const int PoisonLifeDivider = 10;

        //Character
        public static char[] characterNameForbiddenSymbols = new char[] { '!', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '@', '#', '$', '%', '^', '&', '*', '(', ')',
            ',', '-', '=', '_', '+', '[', ']', '{', '}', ':', ';', '/', '\'', '|', '.', '?', '<', '>', '~', '`'};

        public const int CharacterNameMaxValue = 16;
        public const int CharacterLevelMinValue = 1;
        public const int CharacterLevelMaxValue = 99;
        public const int CharacterResistanceMaxValue = 90;

        //Gear
        public const int MaxGearItemCount = 4;
        public const int MaxArmorsCount = 1;
        public const int MaxHelmsCount = 1;
        public const int MaxShieldsCount = 1;
        public const int MaxWeaponsCount = 2;

        //Inventory
        public const int InventoryCapacity = 60;

        //Skill
        public const int SkillMaxLevel = 10;

        //Enums
        public const int EnumMinValue = 1;
        public const int MonsterTypeEnumMaxValue = 4;

        //Bonus
        public const string BonusString = "Bonus";
    }
}
