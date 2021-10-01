using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;
using ConsoleDiablo2.Services.Contracts.ViewModels;
using ConsoleDiablo2.Services.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class InventoryMenu : Menu, IInfoHoldingMenu
    {
        private ILabelFactory labelFactory;
        private ICharacterService characterService;
        private IItemService itemService;
        private ICommandFactory commandFactory;

        private ICharacterViewModel characterViewModel;
        private List<ItemViewModel> itemViewModels;

        public InventoryMenu(ILabelFactory labelFactory, ICharacterService characterService,
            IItemService itemService, ICommandFactory commandFactory)
        {
            this.labelFactory = labelFactory;
            this.characterService = characterService;
            this.itemService = itemService;
            this.commandFactory = commandFactory;
            this.BackMenu = typeof(CreateCharacterMenu).Name;
            this.IsReturningMenu = true;
        }

        public int Id { get; set; } //characterId

        public override IMenu ExecuteCommand()
        {
            try
            {
                string commandName = this.CurrentOption.Text;
                int itemId = 0;

                foreach (var itemViewModel in this.itemViewModels)
                {
                    if (itemViewModel.Name.Equals(commandName))
                    {
                        var character = this.characterService.GetCharacterById(this.Id);
                        var item = character.Inventory.Items.FirstOrDefault(i => i.Name == commandName);

                        itemId = item.Id;
                    }
                }

                IMenuCommand command = this.commandFactory.CreateCommand("SelectItem");

                IMenu menu = command.Execute(itemId, this.characterViewModel.Name);

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
            string[] buttonContents = new string[this.itemViewModels.Count + 1];

            buttonContents[0] = "Back";

            Position[] buttonPositions = new Position[buttonContents.Length];

            buttonPositions[0] = new Position(consoleCenter.Left - buttonContents[0].Length / 2, consoleCenter.Top + 18);

            this.Buttons = new IButton[buttonContents.Length];

            this.Buttons[0] = this.labelFactory.CreateButton(buttonContents[0], buttonPositions[0]);

            if (this.itemViewModels.Count > 0)
            {
                for (int i = 1; i < buttonContents.Length; i++)
                {
                    buttonContents[i] = this.itemViewModels[i - 1].Name;
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
            string labelContent = $"{this.characterViewModel.Name} doesn't keep any items in his inventory at the moment.";

            if (this.itemViewModels.Count > 0)
            {
                labelContent = $"{this.characterViewModel.Name} keeps the following items in his inventory:";
            }

            string[] labelContents = new string[]
            {
                labelContent, this.ErrorMessage
            };

            Position[] labelPositions = new Position[]
            {
                new Position(consoleCenter.Left - labelContents[0].Length / 2, consoleCenter.Top - 18),
                new Position(consoleCenter.Left - labelContents[1].Length / 2, consoleCenter.Top + 22), //error
            };

            this.Labels = new ILabel[labelContents.Length];

            for (int i = 0; i < this.Labels.Length; i++)
            {
                this.Labels[i] = new Label(labelContents[i], labelPositions[i]);
            }
        }

        private void LoadViewModels()
        {
            this.characterViewModel = this.characterService.GetCharacterViewModel(this.Id);

            var character = this.characterService.GetCharacterById(this.Id);

            List<ItemViewModel> viewModels = new List<ItemViewModel>(this.itemService.GetAllItemViewModelsInInventory(character.InventoryId));

            this.itemViewModels = new List<ItemViewModel>();

            foreach (var viewModel in viewModels)
            {
                if (viewModel != null)
                {
                    this.itemViewModels.Add(viewModel);
                }
            }
        }

        public void PassInformation(params object[] info)
        {
            this.Id = (int)info[0];

            this.Open();
        }

        public override void Open()
        {
            LoadViewModels();

            base.Open();
        }
    }
}
