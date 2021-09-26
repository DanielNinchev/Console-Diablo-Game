using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.Services.Contracts;
using ConsoleDiablo2.Services.ViewModels;

using System;
using System.Collections.Generic;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class ContinueMenu : Menu, IInfoHoldingMenu
    {
        private ILabelFactory labelFactory;
        private ICharacterService characterService;
        private IItemService itemService;
        private ICommandFactory commandFactory;
        private ItemViewModel itemViewModel;

        private bool itemHasBeenPicked = false;

        private int itemId = 0;
        private Monster monster;

        public ContinueMenu(ILabelFactory labelFactory, ICharacterService characterService,
            IItemService itemService, ICommandFactory commandFactory)
        {
            this.labelFactory = labelFactory;
            this.characterService = characterService;
            this.itemService = itemService;
            this.commandFactory = commandFactory;
            this.BackMenu = typeof(CreateCharacterMenu).Name;
            this.IsReturningMenu = false;
        }

        public int Id { get; set; } //characterId

        public override IMenu ExecuteCommand()
        {
            try
            {
                string commandName = string.Join("", this.CurrentOption.Text.Split()) + "Menu";

                IMenuCommand command = this.commandFactory.CreateCommand(commandName);

                IMenu menu = command.Execute(this.Id, this.itemId, this.monster, this.itemHasBeenPicked);

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
            string[] buttonContents = new string[]
            {
                "Back To Menu", this.itemHasBeenPicked ? null : "Pick Item", 
            };

            List<Position> buttonPositions = new List<Position>()
            {
                new Position(consoleCenter.Left - buttonContents[0].Length / 2, consoleCenter.Top), //Back to menu
            };

            this.Buttons = new IButton[buttonContents.Length];

            if (buttonContents[1] != null)
            {
                buttonPositions.Add(new Position(consoleCenter.Left - buttonContents[1].Length / 2, consoleCenter.Top - 9)); //Pick Item

                for (int i = 0; i < this.Buttons.Length; i++)
                {
                    string buttonContent = buttonContents[i];
                    bool isField = string.IsNullOrWhiteSpace(buttonContent);
                    this.Buttons[i] = this.labelFactory.CreateButton(buttonContent, buttonPositions[i], false, isField);
                }
            }
            else
            {
                this.Buttons = new IButton[1];
                this.Buttons[0] = this.labelFactory.CreateButton(buttonContents[0], buttonPositions[0], false);
            }          
        }

        protected override void InitializeStaticLabels(Position consoleCenter)
        {
            var character = this.characterService.GetCharacterById(this.Id);
            
            string[] labelContents = new string[]
            {
                 $"{this.itemViewModel?.Name}",
                 $"The {this.monster.GetType().Name} dropped the following items: ",                
                 $"Current space in {character.Name}'s inventory: {character.Inventory.Load}/{character.Inventory.Capacity}",                
                 this.ErrorMessage,
            };

            Position[] labelPositions = new Position[]
            {
               new Position(consoleCenter.Left - labelContents[0].Length / 2, consoleCenter.Top - 10),
               new Position(consoleCenter.Left - labelContents[1].Length / 2, consoleCenter.Top - 16),
               new Position(consoleCenter.Left - labelContents[2].Length / 2, consoleCenter.Top - 6),              
               new Position(consoleCenter.Left - labelContents[3].Length / 2, consoleCenter.Top + 5),
            };

            this.Labels = new ILabel[labelContents.Length];

            this.Labels[0] = new Label(labelContents[0], labelPositions[0], this.itemHasBeenPicked);

            for (int i = 1; i < this.Labels.Length; i++)
            {
                this.Labels[i] = new Label(labelContents[i], labelPositions[i]);
            }
        }

        private void LoadViewModels()
        {
            var item = this.itemService.GetItemById(this.itemId);

            if (item.InventoryId == null)
            {
                this.itemHasBeenPicked = false;
                this.itemViewModel = this.itemService.GetItemViewModel(this.itemId);
            }
            else
            {
                this.itemHasBeenPicked = true;
            }          
        }

        public void PassInformation(params object[] info)
        {

            this.Id = (int)info[0];
            this.itemId = (int)info[1];

            if (info.Length > 2)
            {
                this.monster = (Monster)info[2];
            }

            Open();
        }

        public override void Open()
        {
            LoadViewModels();

            base.Open();
        }
    }
}
