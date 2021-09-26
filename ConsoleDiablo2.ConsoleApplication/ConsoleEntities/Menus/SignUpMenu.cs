using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

using System;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class SignUpMenu : Menu
    {
        private bool error;

        private ILabelFactory labelFactory;
        private IGameReader gameReader;
        private ICommandFactory commandFactory;

        public SignUpMenu(ILabelFactory labelFactory, IGameReader gameReader, ICommandFactory commandFactory)
        {
            this.labelFactory = labelFactory;
            this.gameReader = gameReader;
            this.commandFactory = commandFactory;
            this.BackMenu = typeof(MainMenu).Name;
            this.IsReturningMenu = false;

            Open();
        }

        private string AccountNameInput => this.Buttons[0].Text.TrimStart();

        private string PasswordInput => this.Buttons[1].Text.TrimStart();

        public override IMenu ExecuteCommand()
        {
            if (this.CurrentOption.IsField)
            {
                string fieldInput = " " + this.gameReader.ReadLine(this.CurrentOption.Position.Left + 1, this.CurrentOption.Position.Top);

                this.Buttons[this.currentIndex] = this.labelFactory.CreateButton(fieldInput, this.CurrentOption.Position,
                    this.CurrentOption.IsHidden, this.CurrentOption.IsField);

                return this;
            }

            try
            {
                string commandName = string.Join("", this.CurrentOption.Text.Split());

                IMenuCommand command = this.commandFactory.CreateCommand(commandName);
                IMenu menu = command.Execute(this.AccountNameInput, this.PasswordInput);

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
            string[] buttonContents = new string[]
            {
                " ", " ", "Sign Up", "Back"
            };

            Position[] buttonPositions = new Position[]
            {
                new Position(consoleCenter.Left - 10, consoleCenter.Top - 10),  //Account
                new Position(consoleCenter.Left - 6, consoleCenter.Top - 8),    //Password
                new Position(consoleCenter.Left + 16, consoleCenter.Top),       //Sign Up
                new Position(consoleCenter.Left + 16, consoleCenter.Top + 1)    //Back
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
            string[] labelContents = new string[] { this.ErrorMessage, "Name", "Password" };

            Position[] labelPositions = new Position[]
            {
                new Position(consoleCenter.Left - this.ErrorMessage?.Length / 2 ?? 0, consoleCenter.Top - 13),
                new Position(consoleCenter.Left - 16, consoleCenter.Top - 10),
                new Position(consoleCenter.Left - 16, consoleCenter.Top - 8),
            };

            this.Labels = new ILabel[labelContents.Length];

            this.Labels[0] = new Label(labelContents[0], labelPositions[0], !this.error);

            for (int i = 1; i < this.Labels.Length; i++)
            {
                this.Labels[i] = new Label(labelContents[i], labelPositions[i]);
            }
        }
    }
}
