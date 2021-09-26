using ConsoleDiablo2.ConsoleApplication.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.Core;
using ConsoleDiablo2.ConsoleApplication.Core;
using ConsoleDiablo2.Data;
using ConsoleDiablo2.DataModels.Factories;
using ConsoleDiablo2.DataModels.Factories.Contracts;
using ConsoleDiablo2.Services;
using ConsoleDiablo2.Services.Contracts;

using Microsoft.Extensions.DependencyInjection;

using System;

namespace ConsoleDiablo2.ConsoleApplication
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new ConsoleDiabloDbContext();

            //db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            IServiceProvider serviceProvider = ConfigureServices();
            IMainController menu = serviceProvider.GetService<IMainController>();

            Engine engine = new Engine(menu);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<ILabelFactory, LabelFactory>();
            services.AddSingleton<IMenuFactory, MenuFactory>();
            services.AddSingleton<ICommandFactory, CommandFactory>();
            services.AddSingleton<ICharacterFactory, CharacterFactory>();
            services.AddSingleton<IItemFactory, ItemFactory>();
            services.AddSingleton<ISkillFactory, SkillFactory>();
            services.AddSingleton<IMonsterFactory, MonsterFactory>();

            services.AddSingleton<ConsoleDiabloDbContext>();

            services.AddTransient<IMonsterService, MonsterService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<ICharacterService, CharacterService>();
            services.AddTransient<IAccountService, AccountService>();

            services.AddSingleton<ISession, Session>();
            services.AddSingleton<IGameViewEngine, GameViewEngine>();
            services.AddSingleton<IMainController, MenuController>();

            services.AddTransient<IGameReader, GameConsoleReader>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
