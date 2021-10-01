﻿using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using System;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class ShopMenu : Menu, IInfoHoldingMenu
    {
        private ILabelFactory labelFactory;
        private ICommandFactory commandFactory;

        public ShopMenu(ILabelFactory labelFactory, ICommandFactory commandFactory)
        {
            this.labelFactory = labelFactory;
            this.commandFactory = commandFactory;
            this.BackMenu = typeof(CreateCharacterMenu).Name;
            this.IsReturningMenu = false;

            this.Open();
        }

        public int Id { get; set; }

        public override IMenu ExecuteCommand()
        {
            try
            {
                string commandName = string.Join("", this.CurrentOption.Text.Split()) + "Menu";
                string targetCommand = null;

                if (commandName.Contains("Weapons") || commandName.Contains("DefensiveEquipment"))
                {
                    targetCommand = "BuyItemsMenu";
                }
                else if (commandName == "BackMenu")
                {
                    targetCommand = "Back";
                }

                IMenuCommand command = this.commandFactory.CreateCommand(targetCommand);

                IMenu menu = command.Execute(this.Id, commandName);

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
        }

        protected override void InitializeButtons(Position consoleCenter)
        {
            string[] buttonContents = new string[]
            {
                "Buy Weapons", "Buy Defensive Equipment", "Buy Potions", "Gamble", "Back"
            };

            Position[] buttonPositions = new Position[]
            {
                new Position(consoleCenter.Left - buttonContents[0].Length / 2, consoleCenter.Top - 8), //Weapons
                new Position(consoleCenter.Left - buttonContents[1].Length / 2, consoleCenter.Top - 6), //Defensive Equipment
                new Position(consoleCenter.Left - buttonContents[2].Length / 2, consoleCenter.Top - 4), //Potions
                new Position(consoleCenter.Left - buttonContents[3].Length / 2, consoleCenter.Top - 2), //Gamble

                new Position(consoleCenter.Left - buttonContents[4].Length / 2, consoleCenter.Top + 2) //Back
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
