using System;
using System.Collections.Generic;
using ObservableCollections;
using Project.Scripts.Game.GameState.Cmd;
using Project.Scripts.Game.GameState.GameResources;
using Project.Scripts.Game.Idle.Commands;
using Project.Scripts.Game.Idle.View.ResourcesView;
using R3;

namespace Project.Scripts.Game.Idle.Services{
    public class ResourcesService{
        private readonly ObservableList<ResourceViewModel> _resources = new ();
        
        private readonly Dictionary<ResourceType, ResourceViewModel> _resourcesMap = new ();
        private readonly ICommandProcessor _cmd;

        public ResourcesService(ObservableList<Resource>  resources, ICommandProcessor cmd){
            _cmd = cmd;
            resources.ForEach(CreateResourceViewModel);

            resources.ObserveAdd().Subscribe(e => {
                CreateResourceViewModel(e.Value);
            });

            resources.ObserveRemove().Subscribe(e => {
                RemoveResourceViewModel(e.Value);
            });
        }

        public bool AddResources(ResourceType resourceType, int amount){
            var command = new CmdResourcesAdd(resourceType, amount);
            var result = _cmd.Process(command);
            return result;
        }

        public bool TrySpendResources(ResourceType resourceType, int amount){
            var command = new CmdResourcesSpend(resourceType, amount);
            var result = _cmd.Process(command);
            return result;
        }

        public bool IsEnoughResources(ResourceType resourceType, int amount){
            if (_resourcesMap.TryGetValue(resourceType, out var resourceViewModel)){
                return resourceViewModel.Amount.CurrentValue >= amount;
            }
            return false;
        }

        public Observable<int> ObserveResources(ResourceType resourceType){
            if (_resourcesMap.TryGetValue(resourceType, out var resourceViewModel)){
                return resourceViewModel.Amount;
            }
            throw new Exception($"Resource of type {resourceType} not found");
        }

        private void CreateResourceViewModel(Resource resource){
            var resourceViewModel = new ResourceViewModel(resource);
            _resourcesMap[resource.ResourceType] = resourceViewModel;
            
            _resources.Add(resourceViewModel);
        }
        
        private void RemoveResourceViewModel(Resource resource){
            if (_resourcesMap.TryGetValue(resource.ResourceType, out var resourceViewModel)){
                _resources.Remove(resourceViewModel);
                _resourcesMap.Remove(resource.ResourceType);
            }
        }
    }
}