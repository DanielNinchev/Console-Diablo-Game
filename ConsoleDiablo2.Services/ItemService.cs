using ConsoleDiablo2.Common;
using ConsoleDiablo2.Data;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.DataModels.Characters;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Factories.Contracts;
using ConsoleDiablo2.DataModels.Items.Contracts;
using ConsoleDiablo2.DataModels.Items.DefensiveItems;
using ConsoleDiablo2.DataModels.Items.Weapons;
using ConsoleDiablo2.Services.Contracts;
using ConsoleDiablo2.Services.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ConsoleDiablo2.Services
{
    public class ItemService : IItemService
    {
        private ConsoleDiabloDbContext db;
        private ICharacterService characterService;
        private IItemFactory itemFactory;

        public ItemService(ConsoleDiabloDbContext db, ICharacterService characterService, IItemFactory itemFactory)
        {
            this.db = db;
            this.characterService = characterService;
            this.itemFactory = itemFactory;
        }

        public void BuyItemsWithCharacter(int characterId, int itemId)
        {
            var character = this.characterService.GetCharacterById(characterId);
            var item = this.GetItemById(itemId);

            if (character.GoldCoins < item.SellValue)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientFunds);
            }
            else
            {
                this.PickItem(item.Id, characterId);
                character.GoldCoins -= item.SellValue;

                this.db.SaveChanges();
            }
        }

        public List<int> GenerateShopItemsForCharacter(int characterId, string command)
        {
            var character = this.characterService.GetCharacterById(characterId);
            MonsterRank monsterRank;
            Type type;

            if (command.Contains(typeof(Weapon).Name))
            {
                type = typeof(Weapon);
            }
            else
            {
                type = typeof(DefensiveEquipment);
            }

            if (character.Level <= 5)
            {
                monsterRank = MonsterRank.Ordinary;
            }
            else if (character.Level <= 15)
            {
                monsterRank = MonsterRank.Strong;
            }
            else
            {
                monsterRank = MonsterRank.Champion;
            }

            List<int> shopItemIds = new List<int>();
            List<Type> items = Assembly.GetAssembly(type).GetTypes().Where(t => t.IsSubclassOf(type)).ToList();

            for (int i = 0; i < GlobalConstants.ShopMaxWeaponsForSale; i++)
            {
                Random random = new Random();

                int itemId = this.CreateNewItem(items[random.Next(0, items.Count - 1)].Name, monsterRank);
                shopItemIds.Add(itemId);
            }

            return shopItemIds;
        }

        public int CreateNewItem(string itemType, MonsterRank monsterRank)
        {
            Item item = itemFactory.CreateItem(itemType);
            item.Class = item.DrawItemClass(monsterRank);
            item.InitializeItemBonuses(item.Class);

            int counter = 0;

            if (this.db.Items.Any(i => i.Name == item.Name))
            {
                if (item.Name.Contains("("))
                {
                    int counterOfItem = item.Name[item.Name.Length - 2];
                    counter = counterOfItem++;
                    item.Name = item.Name.Remove(item.Name.Length - 2);
                    item.Name = String.Concat(item.Name, $"{counter})");
                }
                else
                {
                    counter++;
                    item.Name = String.Concat(item.Name, $" ({counter})");
                }
            }

            this.db.Items.Add(item);
            this.db.SaveChanges();

            return item.Id;
        }

        public void DeleteItemFromDb(int itemId)
        {
            var item = this.db.Items.FirstOrDefault(i => i.Id == itemId);

            if (item.Gear == null && item.Inventory == null)
            {
                foreach (var bonus in item.Bonuses)
                {
                    bonus.ItemId = 0;
                    bonus.Item = null;
                    this.db.Bonuses.Remove(bonus);
                }

                this.db.Items.Remove(item);
                this.db.SaveChanges();
            }
        }

        public string DrawItemType()
        {
            Random random = new Random();

            List<string> prizes = GetListOfSubclasses<Item>();

            ShuffleAList(prizes, random);

            string typeOfPrize = prizes[random.Next(0, prizes.Count())];

            return typeOfPrize;
        }

        public void DropItemFromGear(int itemId, int characterId)
        {
            Item item = (Item)GetItemById(itemId);

            var character = characterService.GetCharacterById(characterId);

            if (character.Gear.Items.Contains(item))
            {
                character.Gear.Items.Remove(item);
                item.UnaffectCharacter();
            }

            db.SaveChanges();
        }

        public void DropItemFromInventory(int itemId, int characterId)
        {
            Item item = (Item)GetItemById(itemId);

            var character = characterService.GetCharacterById(characterId);

            if (character.Inventory.Items.Contains(item))
            {
                character.Inventory.Items.Remove(item);
                character.Inventory.Load -= item.Size;
            }

            db.SaveChanges();
        }

        public int DropPrize(MonsterRank monsterType)
        {
            var itemType = DrawItemType();

            int itemId = CreateNewItem(itemType, monsterType);

            return itemId;
        }

        public IItem GetItemById(int itemId)
        {
            var item = db.Items.FirstOrDefault(i => i.Id == itemId);

            return item;
        }

        public int GetItemIdByItsName(string itemName)
        {
            IItem item = db.Items.FirstOrDefault(i => i.Name.Equals(itemName));

            if (item == null)
            {
                throw new ArgumentException("There is no such item!");
            }

            return item.Id;
        }

        //Returns a list of all the types of T
        public List<string> GetListOfSubclasses<T>() where T : class
        {
            List<string> types = new List<string>();

            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                types.Add(type.Name);
            }

            return types;
        }

        public void MoveItemToInventory(int itemId, int characterId)
        {
            var item = (Item)GetItemById(itemId);
            var character = (Character)characterService.GetCharacterById(characterId);

            if (character.Inventory.Capacity - character.Inventory.Load >= item.Size)
            {
                RemoveItemFromGear(item, character);
            }

            PickItem(item.Id, character.Id);
        }

        //Checks if the inventory of a character has enough capacity, then adds an item to it
        public void PickItem(int itemId, int characterId)
        {
            var character = characterService.GetCharacterById(characterId);
            var item = (Item)GetItemById(itemId);

            if (character.Inventory.Capacity < item.Size + character.Inventory.Load)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughSpaceInInventory);
            }
            else
            {
                character.Inventory.Load += item.Size;
                character.Inventory.Items.Add(item);
                item.Inventory = character.Inventory;
                item.Inventory.CharacterId = character.Id;
            }

            db.SaveChanges();
        }

        public void PutItemOn(int itemId, int characterId)
        {
            var character = characterService.GetCharacterById(characterId);
            var item = (Item)GetItemById(itemId);

            if (character.Gear.Items.Count() < GlobalConstants.MaxGearItemCount)
            {
                if (character.Gear.ArmorCount < GlobalConstants.MaxArmorsCount && item is IArmor)
                {
                    character.Gear.ArmorCount++;
                }
                else if (character.Gear.HelmCount < GlobalConstants.MaxHelmsCount && item is IHelm)
                {
                    character.Gear.HelmCount++;
                }
                else if (character.Gear.ShieldCount < GlobalConstants.MaxShieldsCount && item is IShield)
                {
                    character.Gear.ShieldCount++;
                }
                else if (character.Gear.WeaponCount == 0 && item is IWeapon &&
                    character.GetType() != typeof(Assassin) && character.GetType() != typeof(Barbarian))
                {
                    character.Gear.WeaponCount++;
                }
                else if (character.Gear.WeaponCount + character.Gear.ShieldCount < GlobalConstants.MaxWeaponsCount && item is IWeapon &&
                    (character.GetType() == typeof(Assassin) || character.GetType() == typeof(Barbarian)))
                {
                    character.Gear.WeaponCount++;
                }
                else
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CannotUseMultipleItemsOfTheSameType, item.GetType().ToString()));
                }

                character.Gear.Items.Add(item);
                item.Gear = character.Gear;
                item.Gear.CharacterId = character.Id;
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.AlreadyFullyEquipped);
            }

            item.AffectCharacter();

            if (character.Inventory.Items.Contains(item))
            {
                character.Inventory.Items.Remove(item);
                character.Inventory.Load = Math.Max(character.Inventory.Load - item.Size, 0);
            }

            db.SaveChanges();
        }

        public void RemoveItemFromGear(Item item, Character character)
        {
            if (item is IWeapon)
            {
                character.Gear.WeaponCount--;

                item.UnaffectCharacter();
            }
            else if (item is IShield)
            {
                character.Gear.ShieldCount--;

                item.UnaffectCharacter();
            }
            else if (item is IArmor)
            {
                character.Gear.ArmorCount--;

                item.UnaffectCharacter();
            }
            else if (item is IHelm)
            {
                character.Gear.HelmCount--;

                item.UnaffectCharacter();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NoSuchItemTypeMessage);
            }

            character.Gear.Items.Remove(item);

            db.SaveChanges();
        }

        public void SellItem(int itemId, int characterId)
        {
            var item = (Item)GetItemById(itemId);
            var character = (Character)characterService.GetCharacterById(characterId);

            if (character.Inventory.Items.Contains(item))
            {
                character.GoldCoins += item.SellValue;

                DropItemFromInventory(itemId, characterId);
            }
            else if (character.Gear.Items.Contains(item))
            {
                character.GoldCoins += item.SellValue;

                RemoveItemFromGear(item, character);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.ItemDoesNotExist);
            }
        }

        public void ShuffleAList<T>(List<T> list, Random rnd)
        {
            for (var i = list.Count; i > 0; i--)
            {
                Swap(list, 0, rnd.Next(1, i));
            }
        }

        public void Swap<T>(List<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public ItemViewModel GetItemViewModel(int itemId)
        {
            var item = GetItemById(itemId);

            List<ItemViewModel> itemViewModels = new List<ItemViewModel>();

            if (item.Gear != null)
            {
                itemViewModels.AddRange(GetAllItemViewModelsInGear((int)item.GearId));
            }

            else if (item.Inventory != null)
            {
                itemViewModels.AddRange(GetAllItemViewModelsInInventory((int)item.InventoryId));
            }

            else
            {
                itemViewModels.AddRange(db.Items.Where(i => i.Id == itemId)
                    .Select(MapToItemViewModel())
                    .ToList());

                if (itemViewModels.Count > 0)
                {
                    return itemViewModels[0];
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.ItemDoesNotExist);
                }
            }

            ItemViewModel itemViewModel = itemViewModels.FirstOrDefault(vm => vm.Name == item.Name);

            return itemViewModel;
        }

        public IEnumerable<ItemViewModel> GetAllItemViewModelsInGear(int gearId)
        {
            var gear = db.Gears.FirstOrDefault(g => g.Id == gearId);

            if (gear != null && gear.Items.Count() > 0)
            {
                return db.Items.Where(i => i.GearId == gearId)
                    .Select(MapToItemViewModel())
                    .ToList();
            }
            else
            {
                List<ItemViewModel> emptyModel = new List<ItemViewModel>();
                return emptyModel;
            }
        }

        public IEnumerable<ItemViewModel> GetAllItemViewModelsInInventory(int inventoryId)
        {
            var inventory = db.Inventories.FirstOrDefault(i => i.Id == inventoryId);

            if (inventory != null)
            {
                return db.Items.Where(i => i.InventoryId == inventoryId)
                    .Select(MapToItemViewModel())
                    .ToList();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InventoryDoesNotExist);
            }
        }

        public IEnumerable<Item> GetAllItemsForShop(List<int> shopItemIds)
        {
            return db.Items.Where(i => shopItemIds.Contains(i.Id)).ToList();
        }

        private static Expression<Func<Item, ItemViewModel>> MapToItemViewModel()
        {
            return x => new ItemViewModel
            {
                Name = x.Name,
                Description = x.InitializeItemDescription(),
                Size = x.Size,
                SellValue = x.SellValue
            };
        }

        //public string FormatItemViewModelToString(ItemViewModel itemViewModel)
        //{
        //    var result = string.Format(ItemConstants.ItemViewModelStringFormat,
        //         itemViewModel.Name,
        //         itemViewModel.Size.ToString(),
        //         itemViewModel.SellValue.ToString(),
        //         itemViewModel.Description);

        //    return result;
        //}
    }
}
//public void BuyItem(int itemId, int characterId)
//{
//    var item = GetItemById(itemId);
//    var character = this.characterService.GetCharacterById(characterId);
//    var inventory = this.characterService.GetCharactersInventoryByHisId(characterId);

//    if (character.MoneyBalance >= item.SellValue )
//    {
//        if (inventory.Load + item.InventoryLoad <= inventory.Capacity)
//        {
//            inventory.ItemIds.Add(item.Id);
//        }
//        else
//        {
//            throw new ArgumentException("Not enough space in the inventory.");
//        }
//    }
//    else
//    {
//        throw new ArgumentException("This item is too expensive!");
//    }
//}