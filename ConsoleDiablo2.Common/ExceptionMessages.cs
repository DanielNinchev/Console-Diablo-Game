namespace ConsoleDiablo2.Common
{
    public static class ExceptionMessages
    {
        //Account
        public const string AccountAlreadyExists = "There is already an account wiht name {0}!";
        public const string AccountDoesNotExist = "There is no such account!";
        public const string InvalidAccountNameOrPasswordLength = "The account name and the password must both be between 3 and 16 characters long!";
        public const string InvalidAccountNameOrPassword = "Invalid account name or password!";

        //Character
        public const string CharacterDoesNotExist = "Such character does not exist!";
        public const string CharacterNameTaken = "There is already a character named {0}!";
        public const string CharacterNameTooShort = "The name of the character must be between 3 and 16 letters long!";
        public const string CharacterTypeIsNotACharacter = "{0} is not a character!";
        public const string InvalidCharacterType = "Character type {0} does not exist!";
        public const string InvalidCharacterName = "The character's name can include only letters (no numbers and symbols allowed)!";
        public const string InsufficientFunds = "Insufficient funds! This item is too expensive for you!";
        public const string NotEnoughManaMessage = "Not enough mana!";
        public const string NotExperiencedEnoughForThisSkillMsg = "You are not experienced enough for this skill!";
        public const string ParentSkillNotDeveloped = "You need to develop {0} first in order to learn this skill!";
        public const string NoSkillPointsLeft = "You don't have any skill points left!";
        public const string NoStatPointsLeft = "You don't have any stat points left!";

        //Item
        public const string AlreadyFullyEquipped = "You are already fully equipped!";
        public const string CannotUseMultipleItemsOfTheSameType = "You cannot use two {0} at the same time!";
        public const string ItemDoesNotExist = "Such item does not exist!";
        public const string ThisIsNotAnItemType = "{0} is not an item!";

        //Inventory
        public const string NotEnoughSpaceInInventory = "Not enough space in inventory!";
        public const string InventoryDoesNotExist = "Such inventory does not exist!";

        //Enums
        public const string NoSuchItemTypeMessage = "Such item type does not exist!";
        public const string NoSuchMonsterTypeMessage = "Such type of monster does not exist!";

        //Monster
        public const string MonsterDoesNotExist = "Such monster does not exist!";
        public const string ThisIsNotAMonster = "{0} is not a monster!";

        //Skill
        public const string SkillDoesNotExist = "Such skill does not exist!";
        public const string ThisIsNotASkill = "{0} is not a skill!";
        public const string YouNeedAWeaponToUseThisSkill = "You need a weapon to use this skill!";
    }
}
