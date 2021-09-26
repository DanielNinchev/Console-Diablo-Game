using System.Collections.Generic;

namespace ConsoleDiablo2.Services.ViewModels
{
    public class ItemViewModel
    {
        public List<string> Description { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public int SellValue { get; set; }
    }
}
