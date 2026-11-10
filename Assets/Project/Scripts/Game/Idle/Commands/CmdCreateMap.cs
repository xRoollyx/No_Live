using Project.Scripts.Game.GameState.Cmd;

namespace Project.Scripts.Game.Idle.Commands{
    public class CmdCreateMap: ICommand{
        public readonly int MapId;
        public CmdCreateMap(int mapId){
            MapId = mapId;
        }
    }
}