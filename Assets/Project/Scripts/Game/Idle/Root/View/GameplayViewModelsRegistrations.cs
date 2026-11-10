using Project.Scripts.DI;
using Project.Scripts.Game.Idle.Cheats;
using Project.Scripts.Game.Idle.Services;
using Project.Scripts.Game.Idle.View.UI;

namespace Project.Scripts.Game.Idle.Root.View{
    public static class GameplayViewModelsRegistrations{
        public static void Register(DiContainer container){

            container.RegisterFactory(c => new GameplayUiManager(container)).AsSingle();
            
            container.RegisterFactory(c => new UiGameplayRootViewModel(
                c.Resolve<CheatsService>()
                )).AsSingle();
            
            container.RegisterFactory(c => new WorldGameplayRootViewModel(
                c.Resolve<BuildingsService>(),
                c.Resolve<ResourcesService>()
                )).AsSingle();
        }
    }
}