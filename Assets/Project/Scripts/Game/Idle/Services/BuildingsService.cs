using System;
using System.Collections.Generic;
using ObservableCollections;
using Project.Scripts.Game.GameState.Cmd;
using Project.Scripts.Game.GameState.Entities;
using Project.Scripts.Game.GameState.Entities.Mergeable.Buildings;
using Project.Scripts.Game.GameState.GameResources;
using Project.Scripts.Game.Idle.Commands;
using Project.Scripts.Game.Idle.View.BuildingsView;
using Project.Scripts.Game.Settings.Idle.Entities;
using Project.Scripts.Game.Settings.Idle.Entities.Buildings;
using R3;
using UnityEngine;

namespace Project.Scripts.Game.Idle.Services{
    public class BuildingsService{
        private readonly ICommandProcessor _cmd;
        private readonly ResourcesService _resourcesService;
        private readonly ObservableList<BuildingViewModel> _allBuildings = new();
        private readonly Dictionary<int, BuildingViewModel> _buildingsMap = new();
        private readonly Dictionary<string, BuildingSettings> _buildingSettingsMap = new();
        
        public IObservableCollection<BuildingViewModel> AllBuildings => _allBuildings;
        
        public BuildingsService(
            IObservableCollection<Entity>  entities,
            EntitiesSettings entitiesSettings, 
            ICommandProcessor cmd,
            ResourcesService resourcesService){
                _cmd = cmd;
                _resourcesService = resourcesService;

                foreach (var buildingSettings in entitiesSettings.Buildings){
                    _buildingSettingsMap[buildingSettings.ConfigId] =  buildingSettings;
                }
                
                foreach (var entity in entities){
                    if (entity is BuildingEntity buildingEntity){
                        CreateBuildingViewModel(buildingEntity);
                    }
                }

                entities.ObserveAdd().Subscribe(e => {
                    if (e.Value is BuildingEntity buildingEntity){
                        CreateBuildingViewModel(buildingEntity);
                    }
                });
                entities.ObserveRemove().Subscribe(e => {
                    if (e.Value is BuildingEntity buildingEntity){
                        RemoveBuildingViewModel(buildingEntity);
                    }
                });
        }

        public bool PlaceBuilding(string entityConfigId, int level, Vector2Int position){
            var command = new CmdPlaceEntity(EntityType.Building, entityConfigId, level, position);
            var result = _cmd.Process(command);
            
            return result;
        }

        public bool MoveBuilding(int buildingEntityId, Vector3Int newPosition){
            throw new NotImplementedException();
        }

        public bool DeleteBuilding(int buildingEntityId){
            throw new NotImplementedException();
        }

        public void CollectCoins(int coinsAmount){
            _resourcesService.AddResources(ResourceType.SoftCurrency, coinsAmount);
        }

        private void CreateBuildingViewModel(BuildingEntity buildingEntity){
            var buildingSettings = _buildingSettingsMap[buildingEntity.ConfigId];
            var buildingViewModel = new BuildingViewModel(buildingEntity, buildingSettings, this);
            _allBuildings.Add(buildingViewModel);
            _buildingsMap[buildingEntity.UniqueId] = buildingViewModel;
        }

        private void RemoveBuildingViewModel(BuildingEntity  buildingEntity){
            if (_buildingsMap.TryGetValue(buildingEntity.UniqueId, out var buildingViewModel)){
                _allBuildings.Remove(buildingViewModel);
                _buildingsMap.Remove(buildingEntity.UniqueId);
            }
        }
    }
}