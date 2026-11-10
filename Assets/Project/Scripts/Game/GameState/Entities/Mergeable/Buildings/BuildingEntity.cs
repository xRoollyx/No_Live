using R3;

namespace Project.Scripts.Game.GameState.Entities.Mergeable.Buildings{
    public class BuildingEntity: MergeableEntity{
        
         public readonly ReactiveProperty<double> LastClickedTimerMs;
         public readonly ReactiveProperty<bool> IsAutoCollectionEnabled;
        
        public BuildingEntity(BuildingEntityData data) : base(data){
            LastClickedTimerMs = new ReactiveProperty<double>(data.LastClickedTimerMs);
            IsAutoCollectionEnabled = new ReactiveProperty<bool>(data.IsAutoCollectionEnabled);
            
            LastClickedTimerMs.Subscribe(newLastClickedTimerMs => data.LastClickedTimerMs = newLastClickedTimerMs);
            IsAutoCollectionEnabled.Subscribe(newIsAutoCollectionEnabled => data.IsAutoCollectionEnabled = newIsAutoCollectionEnabled);
        }
    }
}