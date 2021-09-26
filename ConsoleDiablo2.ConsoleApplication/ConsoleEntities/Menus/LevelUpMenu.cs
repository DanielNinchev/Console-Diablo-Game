using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;

using System;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class LevelUpMenu : Menu, IInfoHoldingMenu
    {
        private ILabelFactory labelFactory;
        private ICommandFactory commandFactory;
        private ICharacterService characterService;

        public LevelUpMenu(ILabelFactory labelFactory, ICommandFactory commandFactory, ICharacterService characterService)
        {
            this.labelFactory = labelFactory;
            this.commandFactory = commandFactory;
            this.characterService = characterService;
            this.BackMenu = typeof(CreateCharacterMenu).Name;
            this.IsReturningMenu = false;
        }
        public int Id { get; set; }

        public override IMenu ExecuteCommand()
        {
            try
            {
                string commandName = string.Join("", this.CurrentOption.Text.Split()) + "Menu";

                IMenuCommand command = this.commandFactory.CreateCommand(commandName);

                IMenu menu = command.Execute(this.Id);

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
                "Back", "Develop Stats", "Develop Skills", 
            };

            Position[] buttonPositions = new Position[]
            {
                new Position(consoleCenter.Left - buttonContents[0].Length / 2, consoleCenter.Top + 2), //Back
                new Position(consoleCenter.Left - buttonContents[1].Length / 2, consoleCenter.Top - 4), // Develop Stats
                new Position(consoleCenter.Left - buttonContents[2].Length / 2, consoleCenter.Top - 2), // Develop Skills
            };

            var character = this.characterService.GetCharacterById(this.Id);

            bool[] buttonConditions = new bool[]
            {
                false,
                character.StatusPoints <= 0,
                character.SkillPoints <= 0,
            };

            this.Buttons = new IButton[buttonContents.Length];

            for (int i = 0; i < Buttons.Length; i++)
            {
                this.Buttons[i] = this.labelFactory.CreateButton(buttonContents[i], buttonPositions[i], buttonConditions[i]);
            }
        }

        protected override void InitializeStaticLabels(Position consoleCenter)
        {
            string[] labelContents = new string[] 
            { 
                "You have gained a level!",
                this.ErrorMessage 
            };

            Position[] labelPositions = new Position[]
            {
                new Position(consoleCenter.Left - labelContents[0].Length / 2, consoleCenter.Top - 10),
                new Position(consoleCenter.Left - labelContents[1].Length / 2, consoleCenter.Top + 10),
            };

            this.Labels = new ILabel[labelContents.Length];

            for (int i = 0; i < this.Labels.Length; i++)
            {
                this.Labels[i] = this.labelFactory.CreateLabel(labelContents[i], labelPositions[i]);
            }
        }
    }
}
