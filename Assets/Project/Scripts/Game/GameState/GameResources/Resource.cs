using R3;

namespace Project.Scripts.Game.GameState.GameResources{
    public class Resource{
        public readonly ResourceData Origin;
        public ResourceType ResourceType => Origin.ResourceType;
        public readonly ReactiveProperty<int>  Amount;

        public Resource(ResourceData data){
            Origin = data;
            Amount = new ReactiveProperty<int>(data.Amount);
            Amount.Subscribe(newValue => data.Amount = newValue);
        }
    }
}