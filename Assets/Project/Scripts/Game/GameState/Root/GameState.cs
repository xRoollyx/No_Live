using System.Linq;
using ObservableCollections;
using Project.Scripts.Game.GameState.GameResources;
using Project.Scripts.Game.GameState.Maps;
using R3;

namespace Project.Scripts.Game.GameState.Root{
    public class GameState{
        private readonly GameStateData _gameStateData;
        public ObservableList<Map>  Maps{ get; } = new();
        public ObservableList<Resource>  Resources{ get; } = new();
        
        public readonly ReactiveProperty<int> CurrentMapId = new();

        public GameState(GameStateData gameStateData){
            _gameStateData = gameStateData;
            
            InitMaps(gameStateData);
            InitResources(gameStateData);
           
           CurrentMapId.Subscribe(newValue => {gameStateData.CurrentMapId = newValue;});
        }

        public int CreateEntityId(){
            return _gameStateData.CreateEntityId();
        }

        private void InitMaps(GameStateData gameStateData){
            gameStateData.Maps.ForEach(mapOrigin => Maps.Add(new Map(mapOrigin)));

            Maps.ObserveAdd().Subscribe(e => {
                var addedMap = e.Value;
                gameStateData.Maps.Add(addedMap.Origin);
            });
            
            Maps.ObserveRemove().Subscribe(e => {
                var removedMap = e.Value;
                var removedMapState = gameStateData.Maps.FirstOrDefault(m => m.Id == removedMap.Id);
                gameStateData.Maps.Remove(removedMapState);
            });
        }

        private void InitResources(GameStateData gameStateData){
            gameStateData.Resources.ForEach(resource => Resources.Add(new Resource(resource)));

            Resources.ObserveAdd().Subscribe(e => {
                var addedResource = e.Value;
                gameStateData.Resources.Add(addedResource.Origin);
            });
            
            Resources.ObserveRemove().Subscribe(e => {
                var removedResource = e.Value;
                var removedResourceData = gameStateData.Resources.FirstOrDefault(r => r.ResourceType == removedResource.ResourceType);
                gameStateData.Resources.Remove(removedResourceData);
            });
        }
        
    }
}