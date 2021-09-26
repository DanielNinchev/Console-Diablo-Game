using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.DataModels.Monsters.Contracts;
using ConsoleDiablo2.Services.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class ChooseSkillMenu : Menu, IMonsterHoldingMenu, ISkillHoldingMenu, IRoundHoldingMenu
    {
        private ILabelFactory labelFactory;
        private ICharacterService characterService;
        private ICommandFactory commandFactory;

        public ChooseSkillMenu(ILabelFactory labelFactory, ICharacterService characterService, ICommandFactory commandFactory)
        {
            this.labelFactory = labelFactory;
            this.characterService = characterService;
            this.commandFactory = commandFactory;
            this.BackMenu = typeof(FightMonsterMenu).Name;
            this.IsReturningMenu = false;
        }

        public int Id { get; set; }

        public string SkillName { get; set; }

        public IMonster Monster { get; set; }

        public int Round { get; set; }

        public override IMenu ExecuteCommand()
        {
            try
            {
                string commandName = string.Join("", this.CurrentOption.Text.Split()) + "Menu";

                IMenuCommand command = this.commandFactory.CreateCommand(typeof(BackCommand).Name.Remove(4));

                var character = this.characterService.GetCharacterById(this.Id);

                foreach (var skill in character.Skills)
                {
                    if (commandName.Contains(string.Join("", skill.Name.Split())))
                    {
                        this.SkillName = skill.Name;

                        command = this.commandFactory.CreateCommand(typeof(UseChosenSkillMenuCommand).Name.Remove(18));

                        break;
                    }
                }

                IMenu menu = command.Execute(this.Id, this.Monster, this.SkillName, this.Round);

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
            this.Monster = (Monster)info[1];
            this.Round = (int)info[3];

            Open();
        }

        protected override void InitializeButtons(Position consoleCenter)
        {
            
            List<string> buttonContents = new List<string>
            {
                "None", "Back"
            };

            var character = this.characterService.GetCharacterById(this.Id);

            var usableSkills = character.Skills.Where(s => s.IsDeveloped && !s.IsPassive && !s.IsActivated);

            foreach (var skill in usableSkills)
            {
                buttonContents.Add(String.Concat(skill.Name, " ", $"(Mana Cost: {skill.ManaCost})"));
            }

            Position[] buttonPositions = new Position[buttonContents.Count];

            buttonPositions[0] = new Position(consoleCenter.Left - buttonContents[0].Length / 2, consoleCenter.Top + 20); // None
            buttonPositions[0] = new Position(consoleCenter.Left - buttonContents[1].Length / 2, consoleCenter.Top + 22); // Back

            for (int i = 2; i < buttonPositions.Length; i++)
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
                this.ErrorMessage,
                $"{character.Name.ToUpper()}'S SKILLS",
                $"Mana Left: {character.Mana}",
                "",
            };

            Position[] labelPositions = new Position[]
            {
               new Position(consoleCenter.Left - labelContents[0].Length / 2, consoleCenter.Top + 15), // error
               new Position(consoleCenter.Left - labelContents[1].Length / 2, consoleCenter.Top - 20), // character's skills
               new Position(consoleCenter.Left - labelContents[2].Length / 2, consoleCenter.Top - 18), // character's skills
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
