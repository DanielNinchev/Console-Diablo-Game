using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.Core;

using System;

using Microsoft.Extensions.DependencyInjection;
using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;

namespace ConsoleDiablo2.ConsoleApplication.Core
{
    internal class MenuController : IMainController
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IGameViewEngine viewEngine;
        private readonly ISession session;

        public MenuController(IServiceProvider serviceProvider, IGameViewEngine viewEngine, ISession session)
        {
            this.serviceProvider = serviceProvider;
            this.viewEngine = viewEngine;
            this.session = session;

            InitializeSession();
        }

        private IMenu CurrentMenu { get => session.CurrentMenu; }

        private void InitializeSession()
        {
            var menu = new MainMenu(session, serviceProvider.GetService<ILabelFactory>(),
                serviceProvider.GetService<ICommandFactory>());

            session.PushView(menu);

            RenderCurrentView(menu);
        }

        private void RenderCurrentView(IMenu menu)
        {
            viewEngine.RenderMenu(menu);
        }

        public void Back()
        {
            var menu = session.Back();
            RenderCurrentView(menu);
        }

        public void Execute()
        {
            session.PushView(CurrentMenu.ExecuteCommand());
            RenderCurrentView(CurrentMenu);
        }

        public void MarkOption()
        {
            viewEngine.Mark(CurrentMenu.CurrentOption);
        }

        public void NextOption()
        {
            CurrentMenu.NextOption();
        }

        public void PreviousOption()
        {
            CurrentMenu.PreviousOption();
        }

        public void UnmarkOption()
        {
            viewEngine.Mark(CurrentMenu.CurrentOption, false);
        }
    }
}
