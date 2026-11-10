using System;
using Project.Scripts.Game.GameState.Entities;
using Project.Scripts.Game.GameState.Entities.Mergeable.Buildings;
using Project.Scripts.Game.Settings.Idle.Entities;
using UnityEngine;

namespace Project.Scripts.Game.Idle.Commands.Handlers{
    public static class EntityDataFactory{
        public static EntityData CreateEntity(EntityInitialStateSettings initialSettings){
            switch (initialSettings.EntityType){
                case EntityType.Building:
                    var buildingEntityData = CreateEntity<BuildingEntityData>(initialSettings);
                    return buildingEntityData;
                default:
                    throw new Exception($"Not implemented entity creation type {initialSettings.EntityType}");
            }
        }

        private static T CreateEntity<T>(EntityInitialStateSettings initialSettings) where T : EntityData, new(){
            return CreateEntity<T>(
                initialSettings.EntityType,
                initialSettings.ConfigId,
                initialSettings.Level,
                initialSettings.InitialPosition);
        }

        public static T CreateEntity<T>(EntityType type, string configId, int level, Vector2Int position) where T : EntityData, new(){
            var entity = new T{
                Type = type,
                ConfigId = configId,
                Level = level,
                Position = position
            };
            
            switch (entity){
                case BuildingEntityData buildingEntityData:
                    UpdateBuildingEntity(buildingEntityData);
                    break;
                default:
                    throw new Exception($"Not implemented entity creation type {type}");
            }
            
            return entity;
        }
        
        private static void UpdateBuildingEntity(BuildingEntityData buildingEntity)
        {
            buildingEntity.LastClickedTimerMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            buildingEntity.IsAutoCollectionEnabled = false;
        }
    }
}