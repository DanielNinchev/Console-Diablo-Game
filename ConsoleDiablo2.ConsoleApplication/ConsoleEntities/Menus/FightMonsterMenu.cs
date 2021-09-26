using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.DataModels.Monsters.Contracts;
using ConsoleDiablo2.Services.Contracts;
using ConsoleDiablo2.Services.ViewModels;

using System;
using System.Collections.Generic;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class FightMonsterMenu : Menu, IMonsterHoldingMenu, ISkillHoldingMenu, IRoundHoldingMenu
    {
        private ILabelFactory labelFactory;
        private ICharacterService characterService;
        private IMonsterService MonsterService;
        private ICommandFactory commandFactory;

        private CharacterViewModel characterViewModel;

        public FightMonsterMenu(ILabelFactory labelFactory, ICharacterService characterService, IMonsterService MonsterService,
            ICommandFactory commandFactory)
        {
            this.labelFactory = labelFactory;
            this.characterService = characterService;
            this.MonsterService = MonsterService;
            this.commandFactory = commandFactory;
            this.BackMenu = typeof(CreateCharacterMenu).Name;
            this.IsReturningMenu = false;
            this.SkillName = SkillDescriptions.NoRequiredSkill;
            this.Round = 1;
        }

        public int Id { get; set; } //characterId

        public string SkillName { get; set; }

        public IMonster Monster { get; set; }

        public int Round { get; set; }

        public override IMenu ExecuteCommand()
        {
            try
            {
                string commandName = string.Join("", this.CurrentOption.Text.Split()) + "Menu";

                IMenuCommand command = this.commandFactory.CreateCommand(commandName);

                IMenu menu = command.Execute(this.Id, this.Monster, this.SkillName, this.Round);

                return menu;
            }
            catch (Exception e)
            {
                this.ErrorMessage = e.Message;
                this.Open();
                return this;
            }
        }

        protected override void InitializeButtons(Position consoleCenter)
        {
            var character = this.characterService.GetCharacterById(this.Id);

            string[] buttonContents = null;
            Position[] buttonPositions = null;

            if (character.IsAlive && Monster.IsAlive)
            {
                buttonContents = new string[]
                {
                    "Attack", "Choose Skill", "Quit Game"
                };

                buttonPositions = new Position[]
                {
                    new Position(consoleCenter.Left - buttonContents[0].Length / 2, consoleCenter.Top + 6),    //Skill attack
                    new Position(consoleCenter.Left - buttonContents[1].Length / 2, consoleCenter.Top + 7),    //Choose skill
                    new Position(consoleCenter.Left - buttonContents[2].Length / 2, consoleCenter.Top + 9),    //Quit
                };
            }
            else if (!character.IsAlive)
            {
                buttonContents = new string[]
                {
                    "Quit Game"
                };

                buttonPositions = new Position[]
                {
                    new Position(consoleCenter.Left - buttonContents[0].Length / 2, consoleCenter.Top + 9),
                };
            }

            else
            {
                buttonContents = new string[]
                {
                    "Continue"
                };

                buttonPositions = new Position[]
                {
                    new Position(consoleCenter.Left - buttonContents[0].Length / 2, consoleCenter.Top + 9),   
                };
            }

            this.Buttons = new IButton[buttonContents.Length];

            for (int i = 0; i < this.Buttons.Length; i++)
            {
                string buttonContent = buttonContents[i];
                bool isField = string.IsNullOrWhiteSpace(buttonContent);
                this.Buttons[i] = this.labelFactory.CreateButton(buttonContent, buttonPositions[i], false, isField);
            }
        }

        public List<string> DetermineWinner()
        {
            List<string> gameResult = new List<string>();

            var character = this.characterService.GetCharacterById(this.Id);

            if (character.IsAlive && !this.Monster.IsAlive)
            {
                gameResult.Add(character.Name);
                gameResult.Add(this.Monster.GetType().Name);
            }
            else if (!character.IsAlive && Monster.IsAlive)
            {
                gameResult.Add(this.Monster.GetType().Name);
                gameResult.Add(character.Name);
            }

            return gameResult;
        }

        protected override void InitializeStaticLabels(Position consoleCenter)
        {
            string conditionalLabel = $"{this.characterViewModel.Name} attacked the {Monster.GetType().Name.ToLower()} with {this.SkillName}" +
                 $" The {Monster.GetType().Name.ToLower()} fought back with a {this.Monster.DamageType.ToString().ToLower()} attack!";

            if (this.characterViewModel.Mana == characterViewModel.BaseMana)
            {
                conditionalLabel = $"{this.characterViewModel.Name} attacked the {Monster.GetType().Name.ToLower()} with a melee attack!" +
                 $" The {Monster.GetType().Name.ToLower()} fought back with a {this.Monster.DamageType.ToString().ToLower()} attack!";
            }

            bool conditionalLabelIsHidden = (this.characterViewModel.BaseLife == this.characterViewModel.Life &&
                this.Monster.BaseLife == this.Monster.Life);

            List<string> gameResult = DetermineWinner();

            if (gameResult.Count != 0)
            {
                conditionalLabel = $"{gameResult[1]} was slain by {gameResult[0]}.";
            }

            string[] labelContents = new string[]
            {
                 $"\"{this.characterViewModel.Name}\" vs \"{this.Monster.GetType().Name}\"",

                 $"\"{this.characterViewModel.Name}\"",
                 $"Life: {this.characterViewModel.Life}/{this.characterViewModel.BaseLife}",
                 $"Mana: {this.characterViewModel.Mana}/{this.characterViewModel.BaseMana}",
                 $"Damage: {this.characterViewModel.Damage}",
                 $"Defense: {this.characterViewModel.Defense}",
                 $"Fire Resistance: {this.characterViewModel.FireResistance}",
                 $"Lightning Resistance: {this.characterViewModel.LightningResistance}",
                 $"Cold Resistance: {this.characterViewModel.ColdResistance}",
                 $"Poison Resistance: {this.characterViewModel.PoisonResistance}",

                 $"\"{this.Monster.GetType().Name}\"",
                 $"Life: {this.Monster.Life}/{this.Monster.BaseLife}",
                 $"Damage: {this.Monster.Damage}",
                 $"Damage Type: {this.Monster.DamageType}",
                 $"Defense: {this.Monster.Defense}",
                 $"Fire Resistance: {this.Monster.FireResistance}",
                 $"Lightning Resistance: {this.Monster.LightningResistance}",
                 $"Cold Resistance: {this.Monster.ColdResistance}",
                 $"Poison Resistance: {this.Monster.PoisonResistance}",

                 $"Round: {this.Round}",
                 $"Chosen Skill: {this.SkillName}",
                 
                 conditionalLabel,
            };

            Position[] labelPositions = new Position[]
            {
               new Position(consoleCenter.Left - labelContents[0].Length / 2, consoleCenter.Top - 18),

               new Position(consoleCenter.Left - labelContents[0].Length / 2 - 40, consoleCenter.Top - 14), //Name
               new Position(consoleCenter.Left - labelContents[0].Length / 2 - 40, consoleCenter.Top - 13), //Life
               new Position(consoleCenter.Left - labelContents[0].Length / 2 - 40, consoleCenter.Top - 12), //Mana
               new Position(consoleCenter.Left - labelContents[0].Length / 2 - 40, consoleCenter.Top - 11), //Damage
               new Position(consoleCenter.Left - labelContents[0].Length / 2 - 40, consoleCenter.Top - 10), //Defense
               new Position(consoleCenter.Left - labelContents[0].Length / 2 - 40, consoleCenter.Top - 9), //FR
               new Position(consoleCenter.Left - labelContents[0].Length / 2 - 40, consoleCenter.Top - 8), //LR
               new Position(consoleCenter.Left - labelContents[0].Length / 2 - 40, consoleCenter.Top - 7), //CR
               new Position(consoleCenter.Left - labelContents[0].Length / 2 - 40, consoleCenter.Top - 6), //PR

               new Position(consoleCenter.Left - labelContents[0].Length / 2 + 40, consoleCenter.Top - 14), //Name
               new Position(consoleCenter.Left - labelContents[0].Length / 2 + 40, consoleCenter.Top - 13), //Life
               new Position(consoleCenter.Left - labelContents[0].Length / 2 + 40, consoleCenter.Top - 12), //Damage
               new Position(consoleCenter.Left - labelContents[0].Length / 2 + 40, consoleCenter.Top - 11), //DamageType
               new Position(consoleCenter.Left - labelContents[0].Length / 2 + 40, consoleCenter.Top - 10), //Defense
               new Position(consoleCenter.Left - labelContents[0].Length / 2 + 40, consoleCenter.Top - 9), //FR
               new Position(consoleCenter.Left - labelContents[0].Length / 2 + 40, consoleCenter.Top - 8), //LR
               new Position(consoleCenter.Left - labelContents[0].Length / 2 + 40, consoleCenter.Top - 7), //CR
               new Position(consoleCenter.Left - labelContents[0].Length / 2 + 40, consoleCenter.Top - 6), //PR

               new Position(consoleCenter.Left - labelContents[0].Length / 2, consoleCenter.Top - 16), //round
               new Position(consoleCenter.Left - labelContents[0].Length / 2, consoleCenter.Top - 4), //Chosen skill
               new Position(consoleCenter.Left - labelContents[21].Length / 2, consoleCenter.Top), //conditional label
            };

            this.Labels = new ILabel[labelContents.Length + 1];

            this.Labels[this.Labels.Length - 2] = this.labelFactory.CreateLabel(conditionalLabel, labelPositions[labelContents.Length - 1], conditionalLabelIsHidden);

            for (int i = 0; i < this.Labels.Length - 2; i++)
            {
                this.Labels[i] = this.labelFactory.CreateLabel(labelContents[i], labelPositions[i]);
            }

            var errorPosition = new Position(consoleCenter.Left - this.ErrorMessage.Length / 2, consoleCenter.Top + 2); //error))

            this.Labels[^1] = this.labelFactory.CreateLabel(this.ErrorMessage, errorPosition);            
        }

        private void LoadViewModels()
        {
            if (this.Monster == null)
            {
                this.Monster = this.MonsterService.CreateMonster(this.Id);
            }
            
            this.characterViewModel = this.characterService.GetCharacterViewModel(this.Id);       
        }

        public void PassInformation(params object[] info)
        {
            this.Id = (int)info[0];

            if (info.Length > 1)
            {
                this.Monster = (Monster)info[1];
            }

            if (info.Length > 2)
            {
                this.SkillName = info[2].ToString();
            }

            if (info.Length > 3)
            {
                this.Round = (int)info[3];
            }

            this.Open();
        }

        public override void Open()
        {
            LoadViewModels();

            base.Open();
        }

        public void RenderSkillTree()
        {
        }
    }
}
