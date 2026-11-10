using Project.Scripts.Game.GameState.Cmd;
using Project.Scripts.Game.GameState.GameResources;

namespace Project.Scripts.Game.Idle.Commands{
    public class CmdResourcesSpend:ICommand{
        public readonly ResourceType ResourceType;
        public readonly int Amount;

        public CmdResourcesSpend(ResourceType resourceType, int amount){
            ResourceType = resourceType;
            Amount = amount;
        }
    }
}