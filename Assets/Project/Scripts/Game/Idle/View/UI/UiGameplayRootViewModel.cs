using Project.Scripts.Game.Idle.Cheats;
using Project.Scripts.MVVM.UI;

namespace Project.Scripts.Game.Idle.View.UI{
    public class UiGameplayRootViewModel: UiRootViewModel{
        public readonly CheatPanelViewModel  CheatPanelViewModel;

        public UiGameplayRootViewModel(CheatsService cheatsService){
            CheatPanelViewModel = new CheatPanelViewModel(cheatsService);
        }
    }
}