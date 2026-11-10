using System.Collections.Generic;
using Project.Scripts.Game.GameState.GameResources;
using Project.Scripts.Game.GameState.Maps;

namespace Project.Scripts.Game.GameState.Root{
    
    public class GameStateData{
        private int GlobalEntityId{ get; set; }
        public int CurrentMapId{ get; set; }
        public List<MapData> Maps{ get; set; }
        public List<ResourceData> Resources{ get; set; }

        public int CreateEntityId(){
            return GlobalEntityId++;
        }
    }
}