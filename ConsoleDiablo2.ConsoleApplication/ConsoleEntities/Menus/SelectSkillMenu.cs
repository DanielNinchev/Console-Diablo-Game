using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class SelectSkillMenu : Menu, ISkillHoldingMenu
    {
        private ILabelFactory labelFactory;
        private ICommandFactory commandFactory;
        private ICharacterService characterService;

        public SelectSkillMenu(ILabelFactory labelFactory, ICommandFactory commandFactory, ICharacterService characterService)
        {
            this.labelFactory = labelFactory;
            this.commandFactory = commandFactory;
            this.characterService = characterService;
            this.BackMenu = typeof(DevelopSkillsMenu).Name;
            this.IsReturningMenu = false;
        }

        public int Id { get; set; }

        public string SkillName { get; set; }

        public override IMenu ExecuteCommand()
        {
            try
            {
                string commandName = string.Join("", this.CurrentOption.Text.Split()) + "Menu";

                IMenuCommand command = this.commandFactory.CreateCommand(commandName);

                IMenu menu = command.Execute(this.Id, this.SkillName);

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
            this.SkillName = info[1].ToString().TrimEnd();

            this.Open();
        }

        public void RenderSkillTree()
        {
            var character = this.characterService.GetCharacterById(this.Id);

            character.SkillTree.PrintDFS();
        }

        protected override void InitializeButtons(Position consoleCenter)
        {
            string[] buttonContents = new string[]
            {
                "Back", "Develop Skill",
            };

            Position[] buttonPositions = new Position[]
            {
                new Position(consoleCenter.Left - buttonContents[0].Length / 2, consoleCenter.Top + 14), //Back
                new Position(consoleCenter.Left - buttonContents[1].Length / 2, consoleCenter.Top + 12), // Develop Skills
            };

            this.Buttons = new IButton[buttonContents.Length];

            for (int i = 0; i < Buttons.Length; i++)
            {
                this.Buttons[i] = this.labelFactory.CreateButton(buttonContents[i], buttonPositions[i]);
            }
        }

        protected override void InitializeStaticLabels(Position consoleCenter)
        {
            var character = this.characterService.GetCharacterById(this.Id);
            var skill = character.Skills.FirstOrDefault(s => s.Name == this.SkillName);

            List<string> labelContents = new List<string>
            {
                this.ErrorMessage,
            };

            for (int i = 0; i < skill.Description.Count; i++)
            {
                labelContents.Add(skill.Description[i]);
            }

            List<Position> labelPositions = new List<Position>(labelContents.Count);

            labelPositions.Add(new Position(consoleCenter.Left - labelContents[0].Length / 2, consoleCenter.Top + 18)); // error

            for (int i = 1; i < labelContents.Count; i++)
            {
                labelPositions.Add(new Position(consoleCenter.Left - labelContents[i].Length / 2, consoleCenter.Top - 14 + i));
            }

            labelContents.Add("");
            labelPositions.Add(new Position(consoleCenter.Left, consoleCenter.Top - 12)); //Skill tree starts here

            this.Labels = new ILabel[labelContents.Count];

            for (int i = 0; i < this.Labels.Length; i++)
            {
                this.Labels[i] = this.labelFactory.CreateLabel(labelContents[i], labelPositions[i]);
            }
        }
    }
}
