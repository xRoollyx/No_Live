using System.Linq;
using Project.Scripts.Game.GameState.Cmd;
using Project.Scripts.Game.GameState.Entities;
using Project.Scripts.Game.GameState.Entities.Mergeable.Buildings;
using UnityEngine;

namespace Project.Scripts.Game.Idle.Commands.Handlers{
    public class CmdPlaceEntityHandler : ICommandHandler<CmdPlaceEntity>{
        private readonly GameState.Root.GameState _gameState;

        public CmdPlaceEntityHandler(GameState.Root.GameState  gameState){
            _gameState = gameState;
        }
        public bool Handle(CmdPlaceEntity command){
            var currentMap = _gameState.Maps.FirstOrDefault(m => m.Id == _gameState.CurrentMapId.CurrentValue);
            if (currentMap == null){
                Debug.LogError($"Could not find Map with Id {_gameState.CurrentMapId.CurrentValue}");
                return false;
            }
            
            var entityConfigId = command.EntityConfigId;
            var entityType = command.EntityType;
            var level = command.Level; 
            var position = command.Position;
            var entityId = _gameState.CreateEntityId();

            var createdEntityData = entityType switch{
                EntityType.Building => EntityDataFactory.CreateEntity<BuildingEntityData>(entityType, entityConfigId,
                    level, position),
                _ => throw new System.NotImplementedException(),
            };
            var createEntity = EntityFactory.CreateEntity(createdEntityData);
            
            
            currentMap.Entities.Add(createEntity);
            return true;
        }
    }
}