using ConsoleDiablo2.DataModels.Bonuses.Contracts;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleDiablo2.DataModels
{
    public class Bonus : IBonus
    {
        public Bonus() : this (0, null)
        {
        }

        public Bonus(int value, string description)
        {
            this.Value = value;
            this.Description = description;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Value { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
