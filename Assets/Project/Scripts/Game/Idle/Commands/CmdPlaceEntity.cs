using Project.Scripts.Game.GameState.Cmd;
using Project.Scripts.Game.GameState.Entities;
using UnityEngine;

namespace Project.Scripts.Game.Idle.Commands{
    public class CmdPlaceEntity : ICommand{
        public readonly EntityType EntityType;
        public readonly string EntityConfigId;
        public readonly Vector2Int Position;
        public readonly int Level;
        
        public CmdPlaceEntity(EntityType entityType, string entityConfigId,int level, Vector2Int position){
            EntityConfigId = entityConfigId;
            Position = position;
            EntityType = entityType;
            Level = level;
        }
    }
}