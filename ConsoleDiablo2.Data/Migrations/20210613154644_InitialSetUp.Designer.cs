﻿// <auto-generated />
using System;
using ConsoleDiablo2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleDiablo2.Data.Migrations
{
    [DbContext(typeof(ConsoleDiabloDbContext))]
    [Migration("20210613154644_InitialSetUp")]
    partial class InitialSetUp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLoggedIn")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Bonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId1")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId2")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ItemId1")
                        .IsUnique()
                        .HasFilter("[ItemId1] IS NOT NULL");

                    b.HasIndex("ItemId2")
                        .IsUnique()
                        .HasFilter("[ItemId2] IS NOT NULL");

                    b.ToTable("Bonuses");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("BaseLife")
                        .HasColumnType("int");

                    b.Property<int>("BaseMana")
                        .HasColumnType("int");

                    b.Property<int>("ChanceOfCriticalHit")
                        .HasColumnType("int");

                    b.Property<int>("ColdResistance")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("DamageType")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Experience")
                        .HasColumnType("float");

                    b.Property<int>("FireResistance")
                        .HasColumnType("int");

                    b.Property<int>("GearId")
                        .HasColumnType("int");

                    b.Property<int>("GoldCoins")
                        .HasColumnType("int");

                    b.Property<bool>("HasLeveledUp")
                        .HasColumnType("bit");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<byte>("Level")
                        .HasColumnType("tinyint");

                    b.Property<int>("Life")
                        .HasColumnType("int");

                    b.Property<double>("LifeRegenerator")
                        .HasColumnType("float");

                    b.Property<int>("LifeTap")
                        .HasColumnType("int");

                    b.Property<int>("LightningResistance")
                        .HasColumnType("int");

                    b.Property<int>("Mana")
                        .HasColumnType("int");

                    b.Property<double>("ManaRegenerator")
                        .HasColumnType("float");

                    b.Property<int>("ManaTap")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("PoisonResistance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("GearId")
                        .IsUnique();

                    b.HasIndex("InventoryId")
                        .IsUnique();

                    b.ToTable("Characters");

                    b.HasDiscriminator<string>("Discriminator").IsComplete(false).HasValue("Character");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Gear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("ArmorCount")
                        .HasColumnType("tinyint");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<byte>("HelmCount")
                        .HasColumnType("tinyint");

                    b.Property<byte>("ShieldCount")
                        .HasColumnType("tinyint");

                    b.Property<byte>("WeaponCount")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Gears");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("FreeSpace")
                        .HasColumnType("int");

                    b.Property<int>("Load")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GearId")
                        .HasColumnType("int");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SellValue")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GearId");

                    b.HasIndex("InventoryId");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeveloped")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPassive")
                        .HasColumnType("bit");

                    b.Property<byte>("Level")
                        .HasColumnType("tinyint");

                    b.Property<int?>("ManaCost")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("RequiredLevel")
                        .HasColumnType("tinyint");

                    b.Property<string>("RequiredSkill")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Skills");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Skill");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Characters.Amazon", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Character");

                    b.ToTable("Characters");

                    b.HasDiscriminator().HasValue("Amazon");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Characters.Assassin", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Character");

                    b.ToTable("Characters");

                    b.HasDiscriminator().HasValue("Assassin");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Characters.Barbarian", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Character");

                    b.ToTable("Characters");

                    b.HasDiscriminator().HasValue("Barbarian");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Characters.Druid", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Character");

                    b.ToTable("Characters");

                    b.HasDiscriminator().HasValue("Druid");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Characters.Necromancer", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Character");

                    b.ToTable("Characters");

                    b.HasDiscriminator().HasValue("Necromancer");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Characters.Paladin", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Character");

                    b.ToTable("Characters");

                    b.HasDiscriminator().HasValue("Paladin");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Characters.Sorceress", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Character");

                    b.ToTable("Characters");

                    b.HasDiscriminator().HasValue("Sorceress");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Items.Weapons.Weapon", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Item");

                    b.Property<bool>("IgnoreTargetsDefense")
                        .HasColumnType("bit");

                    b.ToTable("Items");

                    b.HasDiscriminator().HasValue("Weapon");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BarbarianSkill", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Skill");

                    b.ToTable("Skills");

                    b.HasDiscriminator().HasValue("BarbarianSkill");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Items.Weapons.Axe", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Items.Weapons.Weapon");

                    b.ToTable("Items");

                    b.HasDiscriminator().HasValue("Axe");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Items.Weapons.Flail", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Items.Weapons.Weapon");

                    b.ToTable("Items");

                    b.HasDiscriminator().HasValue("Flail");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Items.Weapons.Spear", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Items.Weapons.Weapon");

                    b.ToTable("Items");

                    b.HasDiscriminator().HasValue("Spear");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Items.Weapons.Sword", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Items.Weapons.Weapon");

                    b.ToTable("Items");

                    b.HasDiscriminator().HasValue("Sword");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.AxeMastery", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BarbarianSkill");

                    b.ToTable("Skills");

                    b.HasDiscriminator().HasValue("AxeMastery");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BattleOrders", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BarbarianSkill");

                    b.Property<int>("RoundDuration")
                        .HasColumnType("int");

                    b.ToTable("Skills");

                    b.HasDiscriminator().HasValue("BattleOrders");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.Berzerk", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BarbarianSkill");

                    b.ToTable("Skills");

                    b.HasDiscriminator().HasValue("Berzerk");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.Ferocity", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BarbarianSkill");

                    b.ToTable("Skills");

                    b.HasDiscriminator().HasValue("Ferocity");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.FlailMastery", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BarbarianSkill");

                    b.ToTable("Skills");

                    b.HasDiscriminator().HasValue("FlailMastery");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.IronSkin", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BarbarianSkill");

                    b.ToTable("Skills");

                    b.HasDiscriminator().HasValue("IronSkin");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.NaturalResistance", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BarbarianSkill");

                    b.ToTable("Skills");

                    b.HasDiscriminator().HasValue("NaturalResistance");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.Shout", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BarbarianSkill");

                    b.Property<int>("RoundDuration")
                        .HasColumnType("int")
                        .HasColumnName("Shout_RoundDuration");

                    b.ToTable("Skills");

                    b.HasDiscriminator().HasValue("Shout");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.Stun", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BarbarianSkill");

                    b.ToTable("Skills");

                    b.HasDiscriminator().HasValue("Stun");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.SwordMastery", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BarbarianSkill");

                    b.ToTable("Skills");

                    b.HasDiscriminator().HasValue("SwordMastery");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.WarCry", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BarbarianSkill");

                    b.Property<int>("RoundDuration")
                        .HasColumnType("int")
                        .HasColumnName("WarCry_RoundDuration");

                    b.ToTable("Skills");

                    b.HasDiscriminator().HasValue("WarCry");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.Whirlwind", b =>
                {
                    b.HasBaseType("ConsoleDiablo2.DataModels.Skills.BarbarianSkills.BarbarianSkill");

                    b.ToTable("Skills");

                    b.HasDiscriminator().HasValue("Whirlwind");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Bonus", b =>
                {
                    b.HasOne("ConsoleDiablo2.DataModels.Item", "Item")
                        .WithMany("Bonuses")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ConsoleDiablo2.DataModels.Item", null)
                        .WithOne("AllSkillsBonus")
                        .HasForeignKey("ConsoleDiablo2.DataModels.Bonus", "ItemId1");

                    b.HasOne("ConsoleDiablo2.DataModels.Item", null)
                        .WithOne("SkillBonus")
                        .HasForeignKey("ConsoleDiablo2.DataModels.Bonus", "ItemId2");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Character", b =>
                {
                    b.HasOne("ConsoleDiablo2.DataModels.Account", "Account")
                        .WithMany("Characters")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleDiablo2.DataModels.Gear", "Gear")
                        .WithOne("Character")
                        .HasForeignKey("ConsoleDiablo2.DataModels.Character", "GearId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ConsoleDiablo2.DataModels.Inventory", "Inventory")
                        .WithOne("Character")
                        .HasForeignKey("ConsoleDiablo2.DataModels.Character", "InventoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Gear");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Item", b =>
                {
                    b.HasOne("ConsoleDiablo2.DataModels.Gear", "Gear")
                        .WithMany("Items")
                        .HasForeignKey("GearId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsoleDiablo2.DataModels.Inventory", "Inventory")
                        .WithMany("Items")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Gear");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Skill", b =>
                {
                    b.HasOne("ConsoleDiablo2.DataModels.Character", "Character")
                        .WithMany("Skills")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Account", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Character", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Gear", b =>
                {
                    b.Navigation("Character");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Inventory", b =>
                {
                    b.Navigation("Character");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("ConsoleDiablo2.DataModels.Item", b =>
                {
                    b.Navigation("AllSkillsBonus");

                    b.Navigation("Bonuses");

                    b.Navigation("SkillBonus");
                });
#pragma warning restore 612, 618
        }
    }
}
