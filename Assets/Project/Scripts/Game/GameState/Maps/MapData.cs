using System.Collections.Generic;
using Project.Scripts.Game.GameState.Entities;

namespace Project.Scripts.Game.GameState.Maps{
    
    public class MapData{
        public int Id{ get; set; }
        public List<EntityData> Entities{ get; set; }
    }
}