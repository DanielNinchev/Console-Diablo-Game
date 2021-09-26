using System.Collections.Generic;

namespace ConsoleDiablo2.Common.ItemConstants
{
    public static class ItemConstants
    {
        public static List<string> weaponNames = new List<string>
        {
            " of Fury",
            " of Terror",
            " of Doom",
            " of Destruction",
            " of Dominance",
            " of Extermination",
            " of Grudge",
        };

        public static List<string> armorNames = new List<string>
        {
            " of Protection",
            " of Defense",
            " of Security",
            " of Hope",
            " of Sanctuary",
            " of Faith",
            " of Safety",
        };

        public const string ItemViewModelStringFormat = 
            "{0}\n" +
            "Size: {1}\n" +
            "Sell Value: {2}\n" +
            "{3}\n";
    }
}
