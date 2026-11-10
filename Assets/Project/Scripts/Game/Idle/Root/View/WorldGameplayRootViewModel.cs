using System;
using ObservableCollections;
using Project.Scripts.Game.GameState.GameResources;
using Project.Scripts.Game.Idle.Services;
using Project.Scripts.Game.Idle.View.BuildingsView;
using R3;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts.Game.Idle.Root.View{
    public class WorldGameplayRootViewModel{
        private readonly ResourcesService _resourcesService;
        
        public readonly IObservableCollection<BuildingViewModel> AllBuildings;

        public WorldGameplayRootViewModel(BuildingsService buildingsService, ResourcesService resourcesService){
            _resourcesService = resourcesService;
            AllBuildings = buildingsService.AllBuildings;

            resourcesService.ObserveResources(ResourceType.SoftCurrency).Subscribe(newValue => {
                Debug.Log($"Resource{ResourceType.SoftCurrency}: {newValue}");
            });
            resourcesService.ObserveResources(ResourceType.HardCurrency).Subscribe(newValue => {
                Debug.Log($"Resource{ResourceType.HardCurrency}: {newValue}");
            });
        }

        public void HandleTestInput(){
            var rResourceType = (ResourceType)Random.Range(0, Enum.GetNames(typeof(ResourceType)).Length);
            var rValue = Random.Range(0, 100);
            var rOperation = Random.Range(0, 2);

            if (rOperation == 0){
                _resourcesService.AddResources(rResourceType, rValue);
                return;
            }
            _resourcesService.TrySpendResources(rResourceType, rValue);
        }
    }
}