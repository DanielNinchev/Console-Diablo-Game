using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

using ConsoleDiablo2.Services.Contracts;

using System;
using System.Collections.Generic;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class DevelopSkillsMenu : Menu, ISkillHoldingMenu
    {
        private ILabelFactory labelFactory;
        private ICommandFactory commandFactory;
        private ICharacterService characterService;

        public DevelopSkillsMenu(ILabelFactory labelFactory, ICommandFactory commandFactory, ICharacterService characterService)
        {
            this.labelFactory = labelFactory;
            this.commandFactory = commandFactory;
            this.characterService = characterService;
            this.BackMenu = typeof(LevelUpMenu).Name;
            this.IsReturningMenu = false;
        }

        public int Id { get; set; }

        public string SkillName { get; set; }

        public override IMenu ExecuteCommand()
        {
            try
            {
                this.SkillName = this.CurrentOption.Text;
                this.SkillName = this.SkillName.Remove(this.SkillName.Length - 4);

                IMenuCommand command = this.commandFactory.CreateCommand(typeof(SkillMenuCommand).Name.Remove(9));

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

            Open();
        }

        protected override void InitializeButtons(Position consoleCenter)
        {
            List<string> buttonContents = new List<string>
            {
                "Back"
            };

            var character = this.characterService.GetCharacterById(this.Id);

            foreach (var skill in character.Skills)
            {
                buttonContents.Add(String.Concat(skill.Name, " ", $"({skill.Level})"));
            }

            Position[] buttonPositions = new Position[buttonContents.Count];

            buttonPositions[0] = new Position(consoleCenter.Left - buttonContents[0].Length / 2, consoleCenter.Top + 20); // Back

            for (int i = 1; i < buttonPositions.Length; i++)
            {
                buttonPositions[i] = new Position(consoleCenter.Left - buttonContents[i].Length / 2, consoleCenter.Top - 8 + i);
            }

            this.Buttons = new IButton[buttonContents.Count];

            for (int i = 0; i < this.Buttons.Length; i++)
            {
                this.Buttons[i] = this.labelFactory.CreateButton(buttonContents[i], buttonPositions[i]);
            }
        }

        protected override void InitializeStaticLabels(Position consoleCenter)
        {
            Console.Clear();
            Console.CursorVisible = false;

            var character = this.characterService.GetCharacterById(this.Id);

            string[] labelContents = new string[]
            {
                 this.ErrorMessage, $"{character.Name.ToUpper()}'S SKILLS", $"Skill Points: ({character.SkillPoints})",
                 "",
            };

            Position[] labelPositions = new Position[]
            {
               new Position(consoleCenter.Left - labelContents[0].Length / 2, consoleCenter.Top + 15), // error
               new Position(consoleCenter.Left - labelContents[1].Length / 2, consoleCenter.Top - 20), // character's skills
               new Position(consoleCenter.Left - labelContents[2].Length / 2, consoleCenter.Top - 18), // character's skills points
               new Position(consoleCenter.Left, consoleCenter.Top - 12), //Skill tree starts here
            };

            this.Labels = new ILabel[labelContents.Length];

            for (int i = 0; i < this.Labels.Length; i++)
            {
                this.Labels[i] = this.labelFactory.CreateLabel(labelContents[i], labelPositions[i], false);
            }
        }

        public void RenderSkillTree()
        {
            var character = this.characterService.GetCharacterById(this.Id);

            character.SkillTree.PrintDFS();
        }
    }
}
