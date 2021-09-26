using System.Collections.Generic;

namespace ConsoleDiablo2.DataModels.Bonuses.Contracts
{
    public interface IBonus
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Value { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
