using System.Collections.Generic;
using ObservableCollections;
using Project.Scripts.Game.Idle.View.BuildingsView;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Scripts.Game.Idle.Root.View{
    public class WorldGameplayRootBinder: MonoBehaviour{
        private  WorldGameplayRootViewModel _viewModel;
        
        private readonly Dictionary<int, BuildingBinder> _createdBuildingsMap = new();
        private readonly CompositeDisposable _disposables = new ();
        
        public void Bind(WorldGameplayRootViewModel viewModel){
            _viewModel = viewModel;
            foreach (var buildingViewModel in viewModel.AllBuildings){
                CreateBuilding(buildingViewModel);
            }
            
            _disposables.Add(viewModel.AllBuildings.ObserveAdd().Subscribe(e => {
                CreateBuilding(e.Value);
            }));
            _disposables.Add(viewModel.AllBuildings.ObserveRemove().Subscribe(e => {
                DestroyBuilding(e.Value);
            }));
        }

        private void OnDestroy(){
            _disposables.Dispose();
        }

        private void CreateBuilding(BuildingViewModel buildingViewModel){
            var buildingLevel = buildingViewModel.Level.CurrentValue;
            var prefabBuilding = Resources.Load<BuildingBinder>($"Idle/Buildings/BuildingDummyLevel {buildingLevel}");

            var createdBuilding = Instantiate(prefabBuilding);
            createdBuilding.Bind(buildingViewModel);
            
            _createdBuildingsMap[buildingViewModel.BuildingEntityId] = createdBuilding;
        }

        private void DestroyBuilding(BuildingViewModel buildingViewModel){
            if (_createdBuildingsMap.TryGetValue(buildingViewModel.BuildingEntityId, out var buildingBinder)){
                Destroy(buildingBinder.gameObject);
                _createdBuildingsMap.Remove(buildingViewModel.BuildingEntityId);
            }
        }

        private void Update(){
            if (Keyboard.current.spaceKey.wasPressedThisFrame){
                _viewModel.HandleTestInput();
            }
        }
    }
}