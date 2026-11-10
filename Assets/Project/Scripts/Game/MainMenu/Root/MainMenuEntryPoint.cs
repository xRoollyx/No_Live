using Project.Scripts.DI;
using Project.Scripts.Game.GameRoot;
using Project.Scripts.Game.Idle.Root;
using Project.Scripts.GameRoot;
using Project.Scripts.MainMenu.Root.View;
using R3;
using UnityEngine;

namespace Project.Scripts.MainMenu.Root{
    public class MainMenuEntryPoint :MonoBehaviour{
        
        [SerializeField] private UiMainMenuBinder _uiMainMenuRootPrefab;
        
        public Observable<MainMenuExitParams> Run(DiContainer mainMenuDiContainer, MainMenuEnterParams enterParams)
        {
            MainMenuRegistrations.Register(mainMenuDiContainer, enterParams);
            var mainMenuViewModelsContainer = new DiContainer(mainMenuDiContainer);
            MainMenuViewModelsRegistrations.Register(mainMenuViewModelsContainer);

            //Test
            mainMenuViewModelsContainer.Resolve<UiMainMenuRootViewModel>();
            
            var uiScene = Instantiate(_uiMainMenuRootPrefab);
            var uiRootView = mainMenuDiContainer.Resolve<UiRootView>();
            uiRootView.AttachSceneUI(uiScene.gameObject);
            
            var exitSignalSubj = new Subject<Unit>();
            uiScene.Bind(exitSignalSubj);
          
            Debug.Log($"Result: {enterParams?.Result}");

            var idleEnterParams = new GameplayEnterParams( 1);
            var mainMenuExitParams = new MainMenuExitParams(idleEnterParams);
            
            var exitToIdleSceneSignal = exitSignalSubj.Select(_ => mainMenuExitParams);
            
            return exitToIdleSceneSignal;
        }
    }
}