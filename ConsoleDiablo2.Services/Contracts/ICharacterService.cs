using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.DataModels.Characters.Contracts;
using ConsoleDiablo2.Services.ViewModels;

using System.Collections.Generic;

namespace ConsoleDiablo2.Services.Contracts
{
    public interface ICharacterService
    {
        int Attack(params object[] parameters);

        void KillCharacter(int characterId);

        int CreateNewCharacter(int accountId, string characterName, string characterType);

        int GetCharacterIdByHisName(string characterName);

        //ICharacterViewModel GetCharacterViewModel(int characterId);

        void DeleteCharacter(int characterId);

        void DevelopStats(int characterId, string chosenStat);

        void DevelopSkill(int characterId, string chosenSkill);

        void InitializeCharacterSkills(int characterId);

        void LoadCharacterInfoFromDbByHisId(int characterId);

        ICharacter GetCharacterById(int characterId);

        Skill GetCharacterSkillByItsName(Character character, string skillName);

        CharacterViewModel GetCharacterViewModel(int characterId);

        void LevelUp(int characterId);

        void Recover(int characterId);

        void Regenerate(int characterId);

        IEnumerable<CharacterViewModel> GetAllCharacterViewModelsInAccount(int accountId);
    }
}
