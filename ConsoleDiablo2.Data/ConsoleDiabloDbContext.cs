using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.DataModels.Characters;
using ConsoleDiablo2.DataModels.Items.DefensiveItems;
using ConsoleDiablo2.DataModels.Items.Weapons;
using ConsoleDiablo2.DataModels.Skills.AmazonSkills;
using ConsoleDiablo2.DataModels.Skills.AssassinSkills;
using ConsoleDiablo2.DataModels.Skills.BarbarianSkills;

using Microsoft.EntityFrameworkCore;

namespace ConsoleDiablo2.Data
{
    public class ConsoleDiabloDbContext : DbContext
    {
        public ConsoleDiabloDbContext()
        {
            
        }

        public ConsoleDiabloDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Bonus> Bonuses { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Gear> Gears { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.DefConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Character
            modelBuilder.Entity<Character>().ToTable("Characters");
            modelBuilder.Entity<Amazon>().ToTable("Characters");
            modelBuilder.Entity<Assassin>().ToTable("Characters");
            modelBuilder.Entity<Barbarian>().ToTable("Characters");
            modelBuilder.Entity<Druid>().ToTable("Characters");
            modelBuilder.Entity<Necromancer>().ToTable("Characters");
            modelBuilder.Entity<Paladin>().ToTable("Characters");
            modelBuilder.Entity<Sorceress>().ToTable("Characters");

            //Item
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Weapon>().ToTable("Items");
            modelBuilder.Entity<Axe>().ToTable("Items");
            modelBuilder.Entity<Dagger>().ToTable("Items");
            modelBuilder.Entity<Flail>().ToTable("Items");
            modelBuilder.Entity<Scepter>().ToTable("Items");
            modelBuilder.Entity<Spear>().ToTable("Items");
            modelBuilder.Entity<Staff>().ToTable("Items");
            modelBuilder.Entity<Sword>().ToTable("Items");
            modelBuilder.Entity<Wand>().ToTable("Items");
            modelBuilder.Entity<DefensiveEquipment>().ToTable("Items");
            modelBuilder.Entity<Armor>().ToTable("Items");
            modelBuilder.Entity<Helm>().ToTable("Items");
            modelBuilder.Entity<Shield>().ToTable("Items");

            //Skill
            modelBuilder.Entity<Skill>().ToTable("Skills");

            //Amazon Skill
            modelBuilder.Entity<ChargedStrike>().ToTable("Skills");
            modelBuilder.Entity<CriticalStrike>().ToTable("Skills");
            modelBuilder.Entity<Dodge>().ToTable("Skills");
            modelBuilder.Entity<Impale>().ToTable("Skills");
            modelBuilder.Entity<InnerSight>().ToTable("Skills");
            modelBuilder.Entity<PassiveMastery>().ToTable("Skills");
            modelBuilder.Entity<PlagueStrike>().ToTable("Skills");
            modelBuilder.Entity<PoisonStrike>().ToTable("Skills");
            modelBuilder.Entity<PowerStrike>().ToTable("Skills");
            modelBuilder.Entity<Seduction>().ToTable("Skills");
            modelBuilder.Entity<SpearMastery>().ToTable("Skills");
            modelBuilder.Entity<Valkyrism>().ToTable("Skills");

            //Assassin Skill
            modelBuilder.Entity<Assassination>().ToTable("Skills");
            modelBuilder.Entity<DaggerMastery>().ToTable("Skills");
            modelBuilder.Entity<DeathSentry>().ToTable("Skills");
            modelBuilder.Entity<Devastation>().ToTable("Skills");
            modelBuilder.Entity<ExplosiveDagger>().ToTable("Skills");
            modelBuilder.Entity<FireDagger>().ToTable("Skills");
            modelBuilder.Entity<HeadshotKick>().ToTable("Skills");
            modelBuilder.Entity<LightningSentry>().ToTable("Skills");
            modelBuilder.Entity<MartialArts>().ToTable("Skills");
            modelBuilder.Entity<ShockWeb>().ToTable("Skills");
            modelBuilder.Entity<Venom>().ToTable("Skills");
            modelBuilder.Entity<WeaponBlock>().ToTable("Skills");


            //Barbarian Skill
            modelBuilder.Entity<AxeMastery>().ToTable("Skills");
            modelBuilder.Entity<BattleOrders>().ToTable("Skills");
            modelBuilder.Entity<Berzerk>().ToTable("Skills");
            modelBuilder.Entity<Ferocity>().ToTable("Skills");
            modelBuilder.Entity<FlailMastery>().ToTable("Skills");
            modelBuilder.Entity<IronSkin>().ToTable("Skills");
            modelBuilder.Entity<NaturalResistance>().ToTable("Skills");
            modelBuilder.Entity<Shout>().ToTable("Skills");
            modelBuilder.Entity<Stun>().ToTable("Skills");
            modelBuilder.Entity<SwordMastery>().ToTable("Skills");
            modelBuilder.Entity<WarCry>().ToTable("Skills");
            modelBuilder.Entity<Whirlwind>().ToTable("Skills");

            modelBuilder.Entity<Account>()
                .HasMany(x => x.Characters)
                .WithOne(x => x.Account)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>()
                .HasDiscriminator()
                .IsComplete(false);

            modelBuilder.Entity<Character>()
                .HasMany(x => x.Skills)
                .WithOne(x => x.Character)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character>()
                .HasOne(x => x.Gear)
                .WithOne(x => x.Character)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character>()
                .HasOne(x => x.Inventory)
                .WithOne(x => x.Character)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Gear>()
                .HasMany(x => x.Items)
                .WithOne(x => x.Gear)
                .OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<Inventory>()
                .HasMany(x => x.Items)
                .WithOne(x => x.Inventory)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                .HasMany(x => x.Bonuses)
                .WithOne(x => x.Item)
                .OnDelete(DeleteBehavior.Restrict);
        }

        //public void InitializeDatabaseTables(ModelBuilder modelBuilder, Character model)
        //{
        //    List<Type> types = new List<Type>();

        //    foreach (Type type in Assembly.GetAssembly(typeof(Character)).GetTypes().Where(myType => myType.IsSubclassOf(typeof(Character))))
        //    {
        //        types.Add(type);
        //    }

        //    foreach (var type in types)
        //    {
        //        object x = null;
        //        x = Convert.ChangeType(x, type);

                
        //    }
        //}
    }
}
