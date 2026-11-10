using System.Collections.Generic;
using Project.Scripts.Game.GameState.Entities.Mergeable.Buildings;
using Project.Scripts.Game.Idle.Services;
using Project.Scripts.Game.Settings.Idle.Entities.Buildings;
using R3;
using UnityEngine;

namespace Project.Scripts.Game.Idle.View.BuildingsView{
    public class BuildingViewModel{
        private readonly BuildingEntity _buildingEntity;
        private readonly BuildingSettings _buildingSettings;
        private readonly BuildingsService _buildingsService;
        private readonly Dictionary<int, BuildingLevelSettings> _levelSettingsMap = new();

        public readonly int BuildingEntityId;
        public readonly string ConfigId;
        public ReadOnlyReactiveProperty<Vector2Int> Position { get; }
        public ReadOnlyReactiveProperty<int> Level { get; }
        

        public BuildingViewModel(
            BuildingEntity buildingEntity, 
            BuildingSettings buildingSettings, 
            BuildingsService  buildingsService){
            
                _buildingEntity = buildingEntity;
                _buildingSettings = buildingSettings;
                _buildingsService = buildingsService;
                BuildingEntityId = buildingEntity.UniqueId;
                ConfigId = buildingEntity.ConfigId;
                Position = buildingEntity.Position;
                Level = buildingEntity.Level;
        
                foreach (var buildingLevelSetting in buildingSettings.Levels){
                    _levelSettingsMap[buildingLevelSetting.Level] =  buildingLevelSetting;
                }
        }
        public BuildingLevelSettings GetLevelSettings(int level){
            return _levelSettingsMap[level];
        }

        public void CollectCoinsClicked(int coinsAmount){
            _buildingsService.CollectCoins(coinsAmount);
        }
    }
}