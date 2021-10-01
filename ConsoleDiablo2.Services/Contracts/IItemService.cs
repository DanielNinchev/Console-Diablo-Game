using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Items.Contracts;
using ConsoleDiablo2.Services.ViewModels;

using System;
using System.Collections.Generic;

namespace ConsoleDiablo2.Services.Contracts
{
    public interface IItemService
    {
        void BuyItemsWithCharacter(int characterId, int itemId);

        int CreateNewItem(string itemType, MonsterRank monsterRank);

        string DrawItemType();

        void DropItemFromGear(int itemId, int characterId);

        void DropItemFromInventory(int itemId, int characterId);

        int DropPrize(MonsterRank monsterRank);

        void DeleteItemFromDb(int itemId);

        List<int> GenerateShopItemsForCharacter(int characterId, string command);

        IItem GetItemById(int itemId);

        int GetItemIdByItsName(string itemName);

        ItemViewModel GetItemViewModel(int itemId);

        IEnumerable<ItemViewModel> GetAllItemViewModelsInGear(int gearId);

        IEnumerable<ItemViewModel> GetAllItemViewModelsInInventory(int inventoryId);

        IEnumerable<Item> GetAllItemsForShop(List<int> shopItemIds);

        List<string> GetListOfSubclasses<T>() where T : class;

        void MoveItemToInventory(int itemId, int characterId);

        void PickItem(int itemId, int characterId);

        void PutItemOn(int itemId, int characterId);

        void RemoveItemFromGear(Item item, Character character);

        void SellItem(int itemId, int characterId);

        void ShuffleAList<T>(List<T> list, Random rnd);

        void Swap<T>(List<T> list, int i, int j);
    }
}
