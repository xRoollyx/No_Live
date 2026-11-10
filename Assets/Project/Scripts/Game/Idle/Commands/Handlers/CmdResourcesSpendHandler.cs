using System.Linq;
using Project.Scripts.Game.GameState.Cmd;
using UnityEngine;

namespace Project.Scripts.Game.Idle.Commands.Handlers{
    public class CmdResourcesSpendHandler: ICommandHandler<CmdResourcesSpend>{
        private readonly GameState.Root.GameState _gameState;

        public CmdResourcesSpendHandler(GameState.Root.GameState gameState){
            _gameState = gameState;
        }
        public bool Handle(CmdResourcesSpend command){
            var requiredResourceType = command.ResourceType;
            var requiredResource = _gameState.Resources.FirstOrDefault(r => r.ResourceType == requiredResourceType);
            if (requiredResource == null){
                Debug.LogWarning("Trying to spend not existing resource");
                return false;
            }

            if (requiredResource.Amount.Value < command.Amount){
                Debug.LogWarning($"Trying to spend more resources than existed({requiredResource.Amount.Value}). Existing resource: {requiredResource}");
                return false;
            }
            
            requiredResource.Amount.Value -= command.Amount;

            return true;
        }
    }
}