using Project.Scripts.MVVM.UI;
using R3;

namespace Project.Scripts.Game.Idle.View.UI.ScreenGameplay{
    public class ScreenGameplayViewModel : WindowViewModel{
        private readonly GameplayUiManager _uiManager;
        private readonly Subject<Unit> _exitSceneRequest;
        public override string Id => "ScreenGameplay";

        public ScreenGameplayViewModel(GameplayUiManager uiManager, Subject<Unit> exitSceneRequest){
            _uiManager = uiManager;
            _exitSceneRequest = exitSceneRequest;
        }
        public void RequestOpenPopupA(){
            _uiManager.OpenPopupA();
        }

        public void RequestOpenPopupB(){
            _uiManager.OpenPopupB();
        }

        public void RequestGoToMainMenu(){
            _exitSceneRequest?.OnNext(Unit.Default);
        }

        public void RequestStartGame(){
            _uiManager.OpenGameScreen();
        }
    }
}