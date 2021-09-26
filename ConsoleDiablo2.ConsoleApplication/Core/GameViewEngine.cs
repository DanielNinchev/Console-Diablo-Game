using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.Core;

using System;
using System.Linq;

namespace ConsoleDiablo2.ConsoleApplication.Core
{
    public class GameViewEngine : IGameViewEngine
    {
        private ConsoleColor backgroundColor;
        private ConsoleColor highlightColor;
        private ConsoleColor hardCodedBgColor = ConsoleColor.Red;
        private ConsoleColor hardCodedHlColor = ConsoleColor.DarkMagenta;
        private ConsoleColor hardCodedFontColor = ConsoleColor.White;

        public GameViewEngine()
        {
            InitializeConsole();
        }

        private ConsoleColor BackgroundColor
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                backgroundColor = value;
            }
        }

        private ConsoleColor HiglightColor
        {
            get
            {
                return highlightColor;
            }
            set
            {
                ConsoleColor maxColor = Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>().Last();

                if (value > maxColor)
                {
                    value = (ConsoleColor)((int)value % (int)maxColor);
                }

                highlightColor = value;
            }
        }
        private void InitializeConsole()
        {
            BackgroundColor = hardCodedBgColor;
            HiglightColor = hardCodedHlColor;

            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = hardCodedFontColor;

            Console.CursorVisible = false;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Clear();
        }

        private void Clear()
        {
            Console.Clear();
            Console.CursorVisible = false;
        }

        public void Mark(ILabel label, bool highlighted = true)
        {
            SetCursorPosition(label.Position.Left, label.Position.Top);

            if (highlighted)
            {
                Console.BackgroundColor = HiglightColor;
            }

            Console.Write(label.Text);

            Console.BackgroundColor = BackgroundColor;
        }

        private void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        public void RenderMenu(IMenu menu)
        {
            Clear();

            if (menu.Labels != null)
            {
                foreach (var label in menu.Labels.Where(l => !l.IsHidden))
                {
                    DisplayLabel(label);
                }
            }

            if (menu is ISkillHoldingMenu)
            {
                var skillMenu = (ISkillHoldingMenu)menu;

                skillMenu.RenderSkillTree();
            }
  
            foreach (var button in menu.Buttons.Where(b => !b.IsHidden))
            {
                DisplayLabel(button);
            }
        }

        private void DisplayLabel(ILabel label)
        {
            SetCursorPosition(label.Position.Left, label.Position.Top);
            Console.WriteLine(label.Text);
        }

        public void ResetBuffer()
        {
            Clear();
            Console.BufferHeight = 30;
        }

        public void SetBufferHeight(int rows)
        {
            Console.BufferHeight = rows;
        }
    }
}
