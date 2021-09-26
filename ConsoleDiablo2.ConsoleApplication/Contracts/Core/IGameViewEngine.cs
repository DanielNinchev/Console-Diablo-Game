using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

namespace ConsoleDiablo2.ConsoleApplication.Contracts.Core
{
    public interface IGameViewEngine
    {
        void RenderMenu(IMenu menu);

        void Mark(ILabel label, bool highlighted = true);

        void SetBufferHeight(int rows);

        void ResetBuffer();
    }
}
