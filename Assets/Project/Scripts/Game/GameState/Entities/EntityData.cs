using UnityEngine;

namespace Project.Scripts.Game.GameState.Entities{
    
    public class EntityData{
        public int UniqueId {get; set;}
        public string ConfigId {get; set;}
        public EntityType Type {get; set;}
        public int Level {get; set;}
        public Vector2Int Position {get; set;}
    }
}