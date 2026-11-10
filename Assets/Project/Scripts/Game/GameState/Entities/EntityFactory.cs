using System;
using Project.Scripts.Game.GameState.Entities.Mergeable.Buildings;
using Project.Scripts.Game.GameState.Entities.Mergeable.ResourcesEntity;

namespace Project.Scripts.Game.GameState.Entities{
    
    public static class EntityFactory{

        public static Entity CreateEntity(EntityData entityData){
            switch (entityData.Type){
                case EntityType.Building:
                    return new BuildingEntity(entityData as BuildingEntityData);
                case EntityType.Resource:
                    return new ResourceEntity(entityData as ResourcesEntityData);
                default:
                    throw new Exception("Unknown entity type" +  entityData.Type);
            }
        }
    }
}