using R3;

namespace Project.Scripts.Game.GameState.Entities.Mergeable{
    public abstract class MergeableEntity : Entity{
        protected MergeableEntity(MergeableEntityData data) : base(data){
            
        }
    }
}