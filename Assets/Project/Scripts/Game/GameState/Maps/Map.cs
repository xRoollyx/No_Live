using System.Linq;
using ObservableCollections;
using Project.Scripts.Game.GameState.Entities;
using R3;

namespace Project.Scripts.Game.GameState.Maps{
    public class Map{
        public ObservableList<Entity> Entities{ get; } = new();
        public MapData Origin{ get; }
        public int Id => Origin.Id;

        public Map(MapData mapData){
            Origin = mapData;
             mapData.Entities.ForEach(entityData => Entities.Add(EntityFactory.CreateEntity(entityData)));
            
             Entities.ObserveAdd().Subscribe(e => {
                var addedEntity = e.Value;
                mapData.Entities.Add(addedEntity.Origin);
            });
            
            Entities.ObserveRemove().Subscribe(e => {
                var removedEntity = e.Value;
                var removedEntityData =
                    mapData.Entities.FirstOrDefault(entityData => entityData.UniqueId == removedEntity.UniqueId);
                mapData.Entities.Remove(removedEntityData);
            });
        }
    }
}