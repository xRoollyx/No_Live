using Project.Scripts.Game.GameState.GameResources;
using R3;
using UnityEditor;

namespace Project.Scripts.Game.Idle.View.ResourcesView{
    public class ResourceViewModel{
        public readonly ResourceType ResourceType;
        public readonly ReadOnlyReactiveProperty<int> Amount;

        public ResourceViewModel(Resource resource){
            ResourceType = resource.ResourceType;
            Amount = resource.Amount;
        }
    }
}