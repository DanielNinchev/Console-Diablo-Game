using System;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities
{
    public struct Position
    {
        public Position(int left, int top)
        {
            this.Left = left;
            this.Top = top;
        }

        public int Top { get; set; }

        public int Left { get; set; }

        public static Position ConsoleCenter()
        {
            int centerTop = Console.WindowHeight / 2;
            int centerLeft = Console.WindowWidth / 2;

            Position center = new Position(centerLeft, centerTop);

            return center;
        }
    }
}