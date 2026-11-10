using Project.Scripts.DI;
using Project.Scripts.Game.Common;
using Project.Scripts.Game.GameRoot;
using Project.Scripts.Game.Idle.Root.View;
using Project.Scripts.Game.Idle.View.UI;
using Project.Scripts.GameRoot;
using Project.Scripts.MainMenu.Root;
using R3;
using UnityEngine;

namespace Project.Scripts.Game.Idle.Root{
    public class GameplayEntryPoint: MonoBehaviour{
        [SerializeField] private UiGameplayRootBinder UiGameplayRootPrefab;
        [SerializeField] private WorldGameplayRootBinder WorldRootBinder;
        
        public Observable<GameplayExitParams> Run(DiContainer idleDiContainer, GameplayEnterParams enterParams)
        {
            GameplayRegistrations.Register(idleDiContainer, enterParams);
            var idleViewModelsContainer = new DiContainer(idleDiContainer);
            GameplayViewModelsRegistrations.Register(idleViewModelsContainer);
            
            //Test
            InitWorlds(idleViewModelsContainer);
            InitUi(idleViewModelsContainer);
            
            var mainMenuEnterParams = new MainMenuEnterParams("Exit result");
            var exitParams = new GameplayExitParams(mainMenuEnterParams);

            var exitSceneRequest = idleDiContainer.Resolve<Subject<Unit>>(AppConstants.EXIT_SCENE_REQUEST_TAG);
            var exitToMainMenuSceneSignal = exitSceneRequest.Select(_ => exitParams);
            
            Debug.Log($"Enter params:  MapId {enterParams.MapId}");
            
            return exitToMainMenuSceneSignal;
        }

        private void InitWorlds(DiContainer viewsContainer){
            WorldRootBinder.Bind(viewsContainer.Resolve<WorldGameplayRootViewModel>());
        }
        
        private void InitUi(DiContainer viewsContainer){
            var uiRoot = viewsContainer.Resolve<UiRootView>();
            var uiSceneRootBinder = Instantiate(UiGameplayRootPrefab);
            uiRoot.AttachSceneUI(uiSceneRootBinder.gameObject);

            var uiSceneRootViewModel = viewsContainer.Resolve<UiGameplayRootViewModel>();
            uiSceneRootBinder.Bind(uiSceneRootViewModel);
            
            var uiManager = viewsContainer.Resolve<GameplayUiManager>();
            uiManager.OpenScreenGameplay();
        }
    }
}