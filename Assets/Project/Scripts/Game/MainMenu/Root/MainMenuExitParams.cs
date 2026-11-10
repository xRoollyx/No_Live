using Project.Scripts.GameRoot;

namespace Project.Scripts.MainMenu.Root{
    public class MainMenuExitParams{
        public SceneEnterParams TargetSceneEnterParams{ get; }
        
        public MainMenuExitParams(SceneEnterParams targetSceneEnterParams){
            TargetSceneEnterParams = targetSceneEnterParams;
        }
    }
}