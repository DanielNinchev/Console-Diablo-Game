using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.Services.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class ShopItemsMenu : Menu, IInfoHoldingMenu
    {
        private ILabelFactory labelFactory;
        private ICommandFactory commandFactory;
        private ICharacterService characterService;
        private IItemService itemService;
        private List<int> shopItemIds;
        private List<Item> items;

        public ShopItemsMenu(ILabelFactory labelFactory, ICommandFactory commandFactory, ICharacterService characterService,
            IItemService itemService)
        {
            this.labelFactory = labelFactory;
            this.commandFactory = commandFactory;
            this.characterService = characterService;
            this.itemService = itemService;
            this.BackMenu = typeof(ShopMenu).Name;
            this.IsReturningMenu = false;
        }

        public int Id { get; set; }

        public override IMenu ExecuteCommand()
        {
            try
            {
                string commandName = this.CurrentOption.Text;

                if (commandName == "BackMenu")
                {
                    commandName = "Back";
                }

                int itemId = this.items.FirstOrDefault(i => i.Name.Equals(commandName)).Id;

                var character = this.characterService.GetCharacterById(this.Id);

                IMenuCommand command = this.commandFactory.CreateCommand("SelectItem");

                IMenu menu = command.Execute(itemId, character.Name, this.Id);

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
            this.shopItemIds = (List<int>)info[1];
            this.items = new List<Item>(this.itemService.GetAllItemsForShop(this.shopItemIds));

            this.Open();
        }

        protected override void InitializeButtons(Position consoleCenter)
        {
            string[] buttonContents = new string[this.items.Count + 1];

            buttonContents[0] = "Back";

            Position[] buttonPositions = new Position[buttonContents.Length];

            buttonPositions[0] = new Position(consoleCenter.Left - buttonContents[0].Length / 2, consoleCenter.Top + 18); //Back

            this.Buttons = new IButton[buttonContents.Length];

            this.Buttons[0] = this.labelFactory.CreateButton(buttonContents[0], buttonPositions[0]); //Back

            if (this.items.Count > 0)
            {
                for (int i = 1; i < buttonContents.Length; i++)
                {
                    buttonContents[i] = this.items[i - 1].Name;
                }

                int yCoordinateCounter = 0;

                for (int i = 1; i < buttonPositions.Length; i++)
                {
                    buttonPositions[i] = new Position(consoleCenter.Left - buttonContents[i].Length / 2, consoleCenter.Top - 14 + yCoordinateCounter);

                    yCoordinateCounter++;
                }

                for (int i = 1; i < this.Buttons.Length; i++)
                {
                    string buttonContent = buttonContents[i];
                    bool isField = string.IsNullOrWhiteSpace(buttonContent);
                    this.Buttons[i] = this.labelFactory.CreateButton(buttonContent, buttonPositions[i], false, isField);
                }
            }
        }

        protected override void InitializeStaticLabels(Position consoleCenter)
        {
            string[] labelContents = new string[] { "SHOP", this.ErrorMessage };

            Position[] labelPositions = new Position[]
            {
                new Position(consoleCenter.Left - labelContents[0].Length / 2, consoleCenter.Top - 10),
                new Position(consoleCenter.Left - labelContents[1].Length / 2, consoleCenter.Top + 10),
            };

            this.Labels = new ILabel[labelContents.Length];

            for (int i = 0; i < this.Labels.Length; i++)
            {
                this.Labels[i] = new Label(labelContents[i], labelPositions[i]);
            }
        }
    }
}
