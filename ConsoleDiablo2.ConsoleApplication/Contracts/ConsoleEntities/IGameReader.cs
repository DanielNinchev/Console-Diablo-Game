namespace ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities
{
    public interface IGameReader
    {
        string ReadLine();

        string ReadLine(int left, int top);

        void HideCursor();

        void ShowCursor();
    }
}
