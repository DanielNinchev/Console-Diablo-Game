namespace ConsoleDiablo2.Services.Contracts.ViewModels
{
    public interface IItemViewModel
    {
        string Description { get; set; }

        string Name { get; set; }

        int Size { get; set; }

        int SellValue { get; set; }
    }
}
