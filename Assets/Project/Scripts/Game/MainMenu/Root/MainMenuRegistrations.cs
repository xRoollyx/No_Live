using Project.Scripts.DI;
using Project.Scripts.Game.GameRoot.Services;
using Project.Scripts.MainMenu.Services;

namespace Project.Scripts.MainMenu.Root{
    public static class MainMenuRegistrations{
        public static void Register(DiContainer container, MainMenuEnterParams mainMenuEnterParams){
            
            container.RegisterFactory(c => new SomeMainMenuService(c.Resolve<SomeCommonService>())).AsSingle();
        }
            
    }
}