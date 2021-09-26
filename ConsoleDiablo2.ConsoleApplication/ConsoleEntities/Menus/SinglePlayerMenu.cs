using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

using System;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class SinglePlayerMenu : Menu
    {
        private ILabelFactory labelFactory;
        private ICommandFactory commandFactory;

        public SinglePlayerMenu(ILabelFactory labelFactory, ICommandFactory commandFactory)
        {
            this.labelFactory = labelFactory;
            this.commandFactory = commandFactory;
            this.BackMenu = typeof(MainMenu).Name;
            this.IsReturningMenu = false;

            this.Open();
        }

        public override IMenu ExecuteCommand()
        {
            try
            {
                string commandName = string.Join("", this.CurrentOption.Text.Split()) + "Menu";

                if (commandName == "BackMenu")
                {
                    commandName = "Back";
                }

                IMenuCommand command = this.commandFactory.CreateCommand(commandName);

                IMenu menu = command.Execute();

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
                "Choose An Existing Character", "Create A New Character", "Back"
            };

            Position[] buttonPositions = new Position[]
            {
                new Position(consoleCenter.Left - buttonContents[0].Length / 2, consoleCenter.Top - 4),
                new Position(consoleCenter.Left - buttonContents[1].Length / 2, consoleCenter.Top - 2),
                new Position(consoleCenter.Left - buttonContents[2].Length / 2, consoleCenter.Top + 2) //Back
            };

            this.Buttons = new IButton[buttonContents.Length];

            for (int i = 0; i < Buttons.Length; i++)
            {
                string buttonContent = buttonContents[i];
                this.Buttons[i] = this.labelFactory.CreateButton(buttonContent, buttonPositions[i]);
            }
        }

        protected override void InitializeStaticLabels(Position consoleCenter)
        {
            string[] labelContents = new string[] { "SINGLE PLAYER", this.ErrorMessage };

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
