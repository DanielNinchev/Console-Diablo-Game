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
    public class ItemMenu : Menu, IInfoHoldingMenu
    {
        private ILabelFactory labelFactory;
        private IItemService itemService;
        private ICommandFactory commandFactory;
        private ISession session;
        private int characterId;

        private ItemViewModel itemViewModel;

        private bool error;

        public ItemMenu(ILabelFactory labelFactory, IItemService itemService, ICommandFactory commandFactory, ISession session)
        {
            this.labelFactory = labelFactory;
            this.itemService = itemService;
            this.commandFactory = commandFactory;
            this.session = session;
            this.IsReturningMenu = true;
        }

        public int Id { get; set; } //itemId

        public override IMenu ExecuteCommand()
        {
            try
            {
                string commandName = string.Join("", this.CurrentOption.Text.Split());

                IMenuCommand command = this.commandFactory.CreateCommand(commandName);

                IMenu menu = command.Execute(this.Id, this.characterId);

                return menu;
            }
            catch (Exception e)
            {
                this.error = true;
                this.ErrorMessage = e.Message;
                this.Open();
                return this;
            }
        }

        protected override void InitializeButtons(Position consoleCenter)
        {
            if (this.itemViewModel != null)
            {
                var secondButton = this.session.History.Peek().GetType() == typeof(GearMenu) ? "Move Item To Inventory" : "Put Item On";

                string[] buttonContents = new string[]
                {
                    "Sell Item", secondButton, "Drop Item", "Back"
                };

                if (this.session.History.Peek().GetType() == typeof(ShopItemsMenu))
                {
                    buttonContents = new string[]
                    {
                        "Buy Item", "Back"
                    };
                }

                Position[] buttonPositions = new Position[buttonContents.Length];

                for (int i = 0; i < buttonContents.Length; i++)
                {
                    buttonPositions[i] = new Position(consoleCenter.Left - buttonContents[i].Length / 2, consoleCenter.Top + i + 15);
                }

                this.Buttons = new IButton[buttonContents.Length];

                for (int i = 0; i < this.Buttons.Length; i++)
                {
                    string buttonContent = buttonContents[i];
                    bool isField = string.IsNullOrWhiteSpace(buttonContent);
                    this.Buttons[i] = this.labelFactory.CreateButton(buttonContent, buttonPositions[i], false, isField);
                }
            }          
        }

        protected override void InitializeStaticLabels(Position consoleCenter)
        {
            List<string> labelContents = new List<string>
            {
                this.itemViewModel.Name,
                "Size: " + this.itemViewModel.Size.ToString(),
                "Sell Value: " + this.itemViewModel.SellValue.ToString(),
            };

            labelContents.AddRange(this.itemViewModel.Description);
            labelContents.Add(this.ErrorMessage);
            
            Position[] labelPositions = new Position[labelContents.Count];

            for (int i = 0; i < labelPositions.Length - 1; i++)
            {
                labelPositions[i] = new Position(consoleCenter.Left - labelContents[i].Length / 2, consoleCenter.Top - 12 + i);
            }

            labelPositions[^1] = new Position(consoleCenter.Left - this.ErrorMessage.Length / 2, consoleCenter.Top + 10);

            this.Labels = new ILabel[labelContents.Count];

            this.Labels[^1] = new Label(labelContents[^1], labelPositions[^1], !this.error);

            for (int i = 0; i < this.Labels.Length - 1; i++)
            {
                this.Labels[i] = new Label(labelContents[i], labelPositions[i]);
            }
        }

        private void LoadViewModels()
        {
            this.itemViewModel = this.itemService.GetItemViewModel(this.Id);
        }

        public void PassInformation(params object[] info)
        {
            this.Id = (int)info[0];

            if (info.Length > 1)
            {
                this.characterId = (int)info[1];
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
