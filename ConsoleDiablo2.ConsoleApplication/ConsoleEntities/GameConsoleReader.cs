using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using System;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities
{
    public class GameConsoleReader : IGameReader
    {
        public void HideCursor()
        {
            this.CursorVisible = false;
        }

        private bool CursorVisible { get => Console.CursorVisible; set => Console.CursorVisible = value; }

        public string ReadLine()
        {
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;

            return this.ReadLine(cursorLeft, cursorTop);
        }

        public string ReadLine(int cursorLeft, int cursorTop)
        {
            ClearRow(cursorLeft, cursorTop);

            ShowCursor();

            string result = Console.ReadLine();

            HideCursor();

            return result;
        }

        private void ClearRow(int cursorLeft, int cursorTop)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);

            Console.Write(new string(' ', Console.LargestWindowWidth - cursorLeft));

            Console.SetCursorPosition(cursorLeft, cursorTop);
        }

        public void ShowCursor()
        {
            this.CursorVisible = true;
        }
    }
}
