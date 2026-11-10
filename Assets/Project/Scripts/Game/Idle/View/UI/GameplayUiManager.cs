using Project.Scripts.DI;
using Project.Scripts.Game.Common;
using Project.Scripts.Game.Idle.Services;
using Project.Scripts.Game.Idle.View.UI.GameScreen;
using Project.Scripts.Game.Idle.View.UI.PopupA;
using Project.Scripts.Game.Idle.View.UI.PopupB;
using Project.Scripts.Game.Idle.View.UI.ScreenGameplay;
using Project.Scripts.MVVM.UI;
using R3;

namespace Project.Scripts.Game.Idle.View.UI{
    public class GameplayUiManager : UiManager{
        private readonly Subject<Unit> _exitScreenRequest;
        
        public GameplayUiManager(DiContainer container) : base(container){
            _exitScreenRequest = container.Resolve<Subject<Unit>>(AppConstants.EXIT_SCENE_REQUEST_TAG);
        }

        public ScreenGameplayViewModel OpenScreenGameplay(){
            var viewModel = new ScreenGameplayViewModel(this, _exitScreenRequest);
            var rootUI = Container.Resolve<UiGameplayRootViewModel>();
            
            rootUI.OpenScreen(viewModel);
            return viewModel;
        }

        public PopupAViewModel OpenPopupA(){
            var popupAViewModel = new PopupAViewModel();
            var rootUI = Container.Resolve<UiGameplayRootViewModel>();
            
            rootUI.OpenPopup(popupAViewModel);
            return popupAViewModel;
        }
        
        public PopupBViewModel OpenPopupB(){
            var popupBViewModel = new PopupBViewModel();
            var rootUI = Container.Resolve<UiGameplayRootViewModel>();
            
            rootUI.OpenPopup(popupBViewModel);
            return popupBViewModel;
        }

        public GameScreenViewModel OpenGameScreen(){
            var viewModel = new GameScreenViewModel(
                this, 
                Container.Resolve<BuildingsService>(),
                Container.Resolve<ResourcesService>());
            var rootUI = Container.Resolve<UiGameplayRootViewModel>();
            
            rootUI.OpenScreen(viewModel);
            return viewModel;
        }
    }
}