using Project.Scripts.MainMenu.Root;

namespace Project.Scripts.Game.Idle.Root{
    public class GameplayExitParams{
        public MainMenuEnterParams MainMenuEnterParams;

        public GameplayExitParams(MainMenuEnterParams mainMenuEnterParams){
            MainMenuEnterParams = mainMenuEnterParams;
        }
    }
}