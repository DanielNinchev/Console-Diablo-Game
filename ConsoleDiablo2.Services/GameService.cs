using ConsoleDiablo2.Data;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.Services.Contracts;

namespace ConsoleDiablo2.Services
{
    public class GameService
    {
        private ConsoleDiabloDbContext db;
        private ICharacterService characterService;
        private IItemService itemService;
        private IMonsterService monsterService;

        public GameService(ConsoleDiabloDbContext db, ICharacterService characterService, 
            IItemService itemService, IMonsterService monsterService)
        {
            this.db = db;
            this.characterService = characterService;
            this.itemService = itemService;
            this.monsterService = monsterService;
        }
    }
}
