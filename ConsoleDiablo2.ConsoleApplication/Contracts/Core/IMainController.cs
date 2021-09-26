namespace ConsoleDiablo2.ConsoleApplication.Contracts.Core
{
    public interface IMainController
    {
        void MarkOption();

        void UnmarkOption();

        void NextOption();

        void PreviousOption();

        void Back();

        void Execute();
    }
}
