using System.Linq;
using Project.Scripts.Game.GameState.Cmd;
using Project.Scripts.Game.GameState.GameResources;
using Project.Scripts.Game.GameState.Root;

namespace Project.Scripts.Game.Idle.Commands.Handlers{
    public class CmdResourcesAddHandler: ICommandHandler<CmdResourcesAdd>{
        private readonly GameState.Root.GameState _gameState;

        public CmdResourcesAddHandler(GameState.Root.GameState gameState){
            _gameState = gameState;
        }
        public bool Handle(CmdResourcesAdd command){
            var requiredResourceType = command.ResourceType;
            var requiredResource = _gameState.Resources.FirstOrDefault(r => r.ResourceType == requiredResourceType);
            if (requiredResource == null){
                requiredResource = CreateNewResource(requiredResourceType);
            }
            
            requiredResource.Amount.Value += command.Amount;
            return true;
        }

        private Resource CreateNewResource(ResourceType resourceType){
            var newResourceData = new ResourceData{
                ResourceType = resourceType,
                Amount = 0
            };
            
            var newResource = new Resource(newResourceData);
            _gameState.Resources.Add(newResource);
            
            return newResource;
        }
    }
}