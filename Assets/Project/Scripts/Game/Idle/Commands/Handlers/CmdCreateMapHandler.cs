using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Game.GameState.Cmd;
using Project.Scripts.Game.GameState.Entities;
using Project.Scripts.Game.GameState.Maps;
using Project.Scripts.Game.Settings;
using UnityEngine;

namespace Project.Scripts.Game.Idle.Commands.Handlers{
    public class CmdCreateMapHandler: ICommandHandler<CmdCreateMap>{
        private readonly GameState.Root.GameState _gameState;
        private readonly GameSettings _gameSettings;

        public CmdCreateMapHandler(GameState.Root.GameState  gameState, GameSettings  gameSettings){
            _gameState = gameState;
            _gameSettings = gameSettings;
        }
        
        public bool Handle(CmdCreateMap command){
            var isMapAlreadyExisted = _gameState.Maps.Any(m => m.Id ==  command.MapId);
            if (isMapAlreadyExisted){
                Debug.LogError($"Map with id {command.MapId} has already been existed.");
                return false;
            }
            
            var newMapSettings = _gameSettings.MapsSettings.Maps.First(m => m.MapId ==  command.MapId);
            var newMapInitialStateSettings = newMapSettings.InitialStateSettings;

            var initialEntities = new List<EntityData>();
            foreach (var entitySettings in newMapInitialStateSettings.Entities){
                var initialEntityData = EntityDataFactory.CreateEntity(entitySettings);
                initialEntityData.UniqueId = _gameState.CreateEntityId();
                initialEntities.Add(initialEntityData);
            }

            var newMapState = new MapData{
                Id = command.MapId,
                Entities = initialEntities,
            };
            
            var newMap = new Map(newMapState);
            
            _gameState.Maps.Add(newMap);
            
            return true;
        }
    }
}