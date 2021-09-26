using ConsoleDiablo2.Common;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleDiablo2.DataModels
{
    public class Inventory
    {
        public Inventory()
        {
            this.Load = 0;
            this.Items = new HashSet<Item>();
        }

        [Key]
        public int Id { get; set; }

        [Range(0, GlobalConstants.InventoryCapacity)]
        public int Load { get; set; }

        [Range(0, GlobalConstants.InventoryCapacity)]
        public int FreeSpace { get; set; }

        [Required]
        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }
        public Character Character { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public int Capacity => GlobalConstants.InventoryCapacity;
    }
}