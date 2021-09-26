using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;
using ConsoleDiablo2.Services.ViewModels;

using System;
using System.Collections.Generic;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class ChooseAnExistingCharacterMenu : Menu, IInfoHoldingMenu
    {
        private ILabelFactory labelFactory;
        private ICharacterService characterService;
        private ICommandFactory commandFactory;
        private List<CharacterViewModel> characterViewModels;

        public ChooseAnExistingCharacterMenu(ILabelFactory labelFactory,
            ICharacterService characterService, ICommandFactory commandFactory)
        {
            this.labelFactory = labelFactory;
            this.characterService = characterService;
            this.commandFactory = commandFactory;
            this.BackMenu = typeof(SinglePlayerMenu).Name;
            this.IsReturningMenu = false;
        }

        public int Id { get; set; } //accountId

        public override IMenu ExecuteCommand()
        {
            try
            {
                string commandName = string.Join("", this.CurrentOption.Text.Split());
                IMenuCommand command = null;
                IMenu menu = null;

                if (this.characterViewModels.Count == 0)
                {
                    command = this.commandFactory.CreateCommand(commandName + "Menu");
                    menu = command.Execute();
                }
                else
                {
                    int characterId = 0;

                    for (int i = 0; i < this.characterViewModels.Count; i++)
                    {
                        if (commandName.Contains(string.Join("", characterViewModels[i].Name.Split())))
                        {
                            characterId = this.characterService.GetCharacterIdByHisName(characterViewModels[i].Name);
                        }
                    }

                    command = this.commandFactory.CreateCommand("SelectCharacter");

                    menu = command.Execute(characterId);
                }

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
            string[] buttonContents = new string[this.characterViewModels.Count];
            Position[] buttonPositions = new Position[buttonContents.Length];

            if (this.characterViewModels.Count != 0)
            {
                for (int i = 0; i < buttonContents.Length; i++)
                {
                    buttonContents[i] =
                        characterViewModels[i].Name + "                     " +
                        characterViewModels[i].Type + "                     " +
                        characterViewModels[i].Level.ToString() + "                     " +
                        characterViewModels[i].DateCreated.ToString();
                }

                int yCoordinateCounter = 0;

                for (int i = 0; i < buttonPositions.Length; i++)
                {
                    buttonPositions[i] = new Position(consoleCenter.Left - buttonContents[i].Length / 2, consoleCenter.Top - 8 + yCoordinateCounter);

                    yCoordinateCounter++;
                }
            }
            else
            {
                buttonContents = new string[] { "Create A New Character" };

                buttonPositions = new Position[] { new Position(consoleCenter.Left - buttonContents[0].Length / 2, consoleCenter.Top) };
            }
                
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
            if (this.characterViewModels.Count != 0)
            {
                string[] labelContents = new string[]
                {
                     "Name:", "Type:", "Level:", "Date Created:", this.ErrorMessage
                };

                Position[] labelPositions = new Position[]
                {
                    new Position(consoleCenter.Left - 45, consoleCenter.Top - 12), //Name
                    new Position(consoleCenter.Left - 20, consoleCenter.Top - 12), //Type
                    new Position(consoleCenter.Left + 5, consoleCenter.Top - 12), //Level
                    new Position(consoleCenter.Left + 30, consoleCenter.Top - 12), //Date Created 
                    new Position(consoleCenter.Left - labelContents[4].Length / 2, consoleCenter.Top + 20), //Error Message
                };

                this.Labels = new ILabel[labelContents.Length];

                for (int i = 0; i < this.Labels.Length; i++)
                {
                    this.Labels[i] = new Label(labelContents[i], labelPositions[i]);
                }
            }
            else
            {
                string[] labelContents = new string[]
                {
                     "You have not created any characters yet.", this.ErrorMessage
                };

                Position[] labelPositions = new Position[]
                {
                    new Position(consoleCenter.Left - labelContents[0].Length / 2, consoleCenter.Top - 2),
                    new Position(consoleCenter.Left - labelContents[1].Length / 2, consoleCenter.Top + 20), //Error Message
                };

                this.Labels = new ILabel[labelContents.Length];

                for (int i = 0; i < this.Labels.Length; i++)
                {
                    this.Labels[i] = new Label(labelContents[i], labelPositions[i]);
                }
            }
        }

        public void PassInformation(params object[] info)
        {
            this.Id = (int)info[0];
 
            Open();
        }

        public override void Open()
        {
            this.characterViewModels = new List<CharacterViewModel>(this.characterService.GetAllCharacterViewModelsInAccount(this.Id));

            base.Open();
        }
    }
}
