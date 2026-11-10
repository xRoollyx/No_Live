using System.Collections;
using Project.Scripts.DI;
using Project.Scripts.Game.GameRoot.Services;
using Project.Scripts.Game.GameState.Providers;
using Project.Scripts.Game.Idle.Root;
using Project.Scripts.Game.Settings;
using Project.Scripts.GameRoot;
using Project.Scripts.MainMenu.Root;
using Project.Scripts.Utils;
using R3;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Game.GameRoot{
    // Главная точка входа для всего проекта
    public class GameEntryPoint{
        
        private static GameEntryPoint _instance;
        private readonly DiContainer _rootContainer =  new();
        private DiContainer _cachedDiContainer;
        private readonly Coroutines _coroutines;
        private readonly UiRootView _uiRootView;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutostartGame(){
            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

        private GameEntryPoint(){
            //создание объекта с компонентом COROUTINES на сцене
            _coroutines = new GameObject(name:"[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);
            
            //Загрузка префаба UI всего проекта
            var prefabUiRoot = Resources.Load<UiRootView>("UiRoot");
            _uiRootView = Object.Instantiate(prefabUiRoot);
            Object.DontDestroyOnLoad(_uiRootView.gameObject);
            _rootContainer.RegisterInstance(_uiRootView);

            //Регистрация загрузчика настроек
            var settingsProvider = new SettingsProvider();
            _rootContainer.RegisterInstance<ISettingsProvider>(settingsProvider);
            
            //Регистрация загрузчика данных
            var gameStateProvider = new PlayerPrefsGameStateProvider();
            _rootContainer.RegisterInstance<IGameStateProvider>(gameStateProvider);
            
            //регистрация сервиса уровня проекта
            _rootContainer.RegisterFactory(_ => new SomeCommonService()).AsSingle();
        }

        private async void RunGame(){
            await _rootContainer.Resolve<ISettingsProvider>().LoadGameSettings();
            
#if UNITY_EDITOR

            // Выполняется в редакторе Unity
            var sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == Scenes.IDLE){
                var idleEnterParams = new GameplayEnterParams( 0);
                _coroutines.StartCoroutine(LoadAndStartIdleScene(idleEnterParams));
                return;
            }

            if (sceneName == Scenes.MAIN_MENU){
                _coroutines.StartCoroutine(LoadAndStartMainMenu());
                return;
            }

            if (sceneName != Scenes.BOOT){
                return;
            }
#endif
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
        }
        
        private IEnumerator LoadAndStartIdleScene(GameplayEnterParams enterParams){
            
            _uiRootView.ShowLoadingScreen();
            _cachedDiContainer?.Dispose();
            
            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.IDLE);
            yield return new WaitForSeconds(1); //null

            var isGameStateLoaded = false;
            _rootContainer.Resolve<IGameStateProvider>().LoadGameState().Subscribe(_ => isGameStateLoaded = true);
            yield return new WaitUntil(() => isGameStateLoaded);
            
            var idleDiContainer = _cachedDiContainer = new DiContainer(_rootContainer);
            var sceneEntryPoint = Object.FindAnyObjectByType<GameplayEntryPoint>();
            sceneEntryPoint.Run(idleDiContainer, enterParams).Subscribe(idleExitParams => {
                _coroutines.StartCoroutine(LoadAndStartMainMenu(idleExitParams.MainMenuEnterParams));
            });
            
            _uiRootView.HideLoadingScreen();
        }
        
        private IEnumerator LoadAndStartMainMenu(MainMenuEnterParams enterParams = null){
            
            _uiRootView.ShowLoadingScreen();
            _cachedDiContainer?.Dispose();
            
            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.MAIN_MENU);
            yield return new WaitForSeconds(1); //null

            
            var mainMenuContainer = _cachedDiContainer = new DiContainer(_rootContainer);
            var sceneEntryPoint = Object.FindAnyObjectByType<MainMenuEntryPoint>();
            sceneEntryPoint.Run(mainMenuContainer, enterParams).Subscribe(mainMenuExitParams => {
                var targetSceneName = mainMenuExitParams.TargetSceneEnterParams.SceneName;

                if (targetSceneName == Scenes.IDLE){
                    _coroutines.StartCoroutine(LoadAndStartIdleScene(mainMenuExitParams.TargetSceneEnterParams.As<GameplayEnterParams>()));
                }
            });
            
            _uiRootView.HideLoadingScreen();
            
        }

        private IEnumerator LoadScene(string sceneName){
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}