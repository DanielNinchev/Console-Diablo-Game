namespace ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities
{
    public interface ILabel : IPositionable
    {
        string Text { get; }

        bool IsHidden { get; }
    }
}
