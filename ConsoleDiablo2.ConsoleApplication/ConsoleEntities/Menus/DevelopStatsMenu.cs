using ConsoleDiablo2.Common;
using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;
using ConsoleDiablo2.Services.ViewModels;

using System;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class DevelopStatsMenu : Menu, IInfoHoldingMenu
    {
        private ILabelFactory labelFactory;
        private ICommandFactory commandFactory;
        private ICharacterService characterService;
        private CharacterViewModel characterViewModel;

        public DevelopStatsMenu(ILabelFactory labelFactory, ICommandFactory commandFactory, ICharacterService characterService)
        {
            this.labelFactory = labelFactory;
            this.commandFactory = commandFactory;
            this.characterService = characterService;
            this.BackMenu = typeof(LevelUpMenu).Name;
            this.IsReturningMenu = false;
        }

        public int Id { get; set; }

        public override IMenu ExecuteCommand()
        {
            try
            {
                IMenuCommand command = this.commandFactory.CreateCommand(typeof(StatMenuCommand).Name.Remove(8));

                IMenu menu = command.Execute(this.Id, this.CurrentOption.Text);

                return menu;
            }
            catch (Exception e)
            {
                this.ErrorMessage = e.Message;
                this.Open();
                return this;
            }
        }

        public void PassInformation(params object[] info)
        {
            this.Id = (int)info[0];

            this.Open();
        }

        protected override void InitializeButtons(Position consoleCenter)
        {
            string[] buttonContents = new string[]
            {
                "Strength", 
                "Dexterity", 
                "Vitality", 
                "Energy", 
                "Back"
            };

            Position[] buttonPositions = new Position[]
            {
                new Position(consoleCenter.Left - 30 - buttonContents[0].Length / 2, consoleCenter.Top - 8),     //Str
                new Position(consoleCenter.Left - 30 - buttonContents[1].Length / 2, consoleCenter.Top - 6),     //Dex
                new Position(consoleCenter.Left - 30 - buttonContents[2].Length / 2, consoleCenter.Top - 4),     //Vit
                new Position(consoleCenter.Left - 30 - buttonContents[3].Length / 2, consoleCenter.Top - 2),     //En

                new Position(consoleCenter.Left - 30 - buttonContents[4].Length / 2, consoleCenter.Top + 8),     //Back
            };

            this.Buttons = new IButton[buttonContents.Length];

            for (int i = 0; i < this.Buttons.Length; i++)
            {
                string buttonContent = buttonContents[i];
                bool isField = string.IsNullOrWhiteSpace(buttonContent);
                this.Buttons[i] = this.labelFactory.CreateButton(buttonContent, buttonPositions[i], false, isField);
            }
        }

        protected override void InitializeStaticLabels(Position consoleCenter)
        {
            var character = this.characterService.GetCharacterById(this.Id);

            string[] labelContents = new string[]
            {
                MenuConstants.StrengthDescription,
                MenuConstants.DexterityDescription,
                MenuConstants.VitalityDescription,
                MenuConstants.EnergyDescription,

                this.characterViewModel.Name,
                $"Stat points: {character.StatusPoints}",
                
                "Level: ", this.characterViewModel.Level.ToString(),
                "Life: ", this.characterViewModel.BaseLife.ToString(),
                "Mana: ", this.characterViewModel.BaseMana.ToString(),
                "Damage: ", this.characterViewModel.Damage.ToString(),
                "Defense: ", this.characterViewModel.Defense.ToString(),
                "Fire Resistance: ", this.characterViewModel.FireResistance.ToString(),
                "Cold Resistance: ", this.characterViewModel.ColdResistance.ToString(),
                "Lightning Resistance: ", this.characterViewModel.LightningResistance.ToString(),
                "Poison Resistance: ", this.characterViewModel.PoisonResistance.ToString(),
                "Gold Coins: ", this.characterViewModel.GoldCoins.ToString(),
                this.ErrorMessage
            };

            Position[] labelPositions = new Position[]
            {
                new Position(consoleCenter.Left, consoleCenter.Top - 9), //StrengthDesc
                new Position(consoleCenter.Left, consoleCenter.Top - 6), //DexDesc
                new Position(consoleCenter.Left, consoleCenter.Top - 3), //VitDesc
                new Position(consoleCenter.Left, consoleCenter.Top), //EnDesc

                new Position(consoleCenter.Left - 100, consoleCenter.Top - 16), //Name
                new Position(consoleCenter.Left - 100, consoleCenter.Top - 14), //characterType
                new Position(consoleCenter.Left - 100, consoleCenter.Top - 9), //Level:
                new Position(consoleCenter.Left - 100 + labelContents[6].Length, consoleCenter.Top - 9), //characterLevel
                new Position(consoleCenter.Left - 100, consoleCenter.Top - 8), //Life:
                new Position(consoleCenter.Left - 100 + labelContents[8].Length, consoleCenter.Top - 8), //chracterBaseLife
                new Position(consoleCenter.Left - 100, consoleCenter.Top - 7), //Mana:
                new Position(consoleCenter.Left - 100 + labelContents[10].Length, consoleCenter.Top - 7), //chracterBaseMana
                new Position(consoleCenter.Left - 100, consoleCenter.Top - 6), //Damage:
                new Position(consoleCenter.Left - 100 + labelContents[12].Length, consoleCenter.Top - 6), //characterDamage
                new Position(consoleCenter.Left - 100, consoleCenter.Top - 5), //Defense:
                new Position(consoleCenter.Left - 100 + labelContents[14].Length, consoleCenter.Top - 5), //characterDefense
                new Position(consoleCenter.Left - 100, consoleCenter.Top - 4), //FR:
                new Position(consoleCenter.Left - 100 + labelContents[16].Length, consoleCenter.Top - 4), //characterFR
                new Position(consoleCenter.Left - 100, consoleCenter.Top - 3), //CR:
                new Position(consoleCenter.Left - 100 + labelContents[18].Length, consoleCenter.Top - 3), //characterCR
                new Position(consoleCenter.Left - 100, consoleCenter.Top - 2), //LR:
                new Position(consoleCenter.Left - 100 + labelContents[20].Length, consoleCenter.Top - 2), //LR
                new Position(consoleCenter.Left - 100, consoleCenter.Top - 1), //PR:
                new Position(consoleCenter.Left - 100 + labelContents[22].Length, consoleCenter.Top - 1), //cPR
                new Position(consoleCenter.Left - 100, consoleCenter.Top), //MoneyBalance:
                new Position(consoleCenter.Left - 100 + labelContents[24].Length, consoleCenter.Top), //cMB

                new Position(consoleCenter.Left - this.ErrorMessage?.Length / 2 ?? 0, consoleCenter.Top + 12), //error
            };

            this.Labels = new ILabel[labelContents.Length];

            this.Labels[^1] = this.labelFactory.CreateLabel(labelContents[^1], labelPositions[^1]);

            for (int i = 0; i < this.Labels.Length - 1; i++)
            {
                this.Labels[i] = this.labelFactory.CreateLabel(labelContents[i], labelPositions[i]);
            }
        }

        public override void Open()
        {
            this.characterViewModel = this.characterService.GetCharacterViewModel(this.Id);

            base.Open();
        }
    }
}
