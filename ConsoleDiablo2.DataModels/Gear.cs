using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleDiablo2.DataModels
{
    public class Gear
    {
        public Gear()
        {
            this.ArmorCount = 0;
            this.HelmCount = 0;
            this.ShieldCount = 0;
            this.WeaponCount = 0;
            this.Items = new HashSet<Item>();
        }

        [Key]
        public int Id { get; set; }

        public byte WeaponCount { get; set; }
               
        public byte ArmorCount { get; set; }
               
        public byte HelmCount { get; set; }
               
        public byte ShieldCount { get; set; }

        [Required]
        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }

        public virtual Character Character { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}