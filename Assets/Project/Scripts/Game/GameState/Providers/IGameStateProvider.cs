using Project.Scripts.Game.GameState.Root;
using R3;

namespace Project.Scripts.Game.GameState.Providers{
    public interface IGameStateProvider{
        public Root.GameState GameState{ get; }
        
        public Observable<Root.GameState> LoadGameState();
        public Observable<bool> SaveGameState();
        public Observable<bool> ResetGameState();
    }
}