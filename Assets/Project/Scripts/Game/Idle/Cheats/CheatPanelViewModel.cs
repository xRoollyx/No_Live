namespace Project.Scripts.Game.Idle.Cheats{
    public class CheatPanelViewModel{
        private readonly CheatsService _cheatsService;

        public CheatPanelViewModel(CheatsService cheatsService){
            _cheatsService = cheatsService;
        }

        public void HandleCheatApplying(string cheatText){
            _cheatsService.TryApplyCheat(cheatText);
        }
    }
}