using Project.Scripts.GameRoot;

namespace Project.Scripts.Game.Idle.Root{
    public class GameplayEnterParams: SceneEnterParams{
        
        
        public int MapId{ get; }
        
        public GameplayEnterParams(int mapId) : base(Scenes.IDLE){
           
            MapId = mapId;
        }
    }
}