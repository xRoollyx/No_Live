using Project.Scripts.DI;

namespace Project.Scripts.MainMenu.Root.View{
    public static class MainMenuViewModelsRegistrations{
        public static void Register(DiContainer container){
            container.RegisterFactory(c => new UiMainMenuRootViewModel());
        }
    }
}