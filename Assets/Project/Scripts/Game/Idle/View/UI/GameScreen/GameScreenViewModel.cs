using Project.Scripts.Game.GameState.GameResources;
using Project.Scripts.Game.Idle.Services;
using Project.Scripts.MVVM.UI;
using R3;
using UnityEngine;

namespace Project.Scripts.Game.Idle.View.UI.GameScreen{
    public class GameScreenViewModel : WindowViewModel{
        private readonly GameplayUiManager _uiManager;
        private readonly BuildingsService _buildingsService;
        private readonly ResourcesService _resourcesService;
        public override string Id => "GameScreen";
        public ReactiveProperty<int> Coins;

        public GameScreenViewModel(GameplayUiManager uiManager, BuildingsService  buildingsService, ResourcesService resourcesService){
            _uiManager = uiManager;
            _buildingsService = buildingsService;
            _resourcesService = resourcesService;
            Coins = (ReactiveProperty<int>)resourcesService.ObserveResources(ResourceType.SoftCurrency);
        }

        public void RequestOpenGameplayScreen(){
            _uiManager.OpenScreenGameplay();
        }

        public void RequestCreateBuilding(){
            var position = new Vector2Int(Random.Range(0, 10), Random.Range(0, 10));
            _buildingsService.PlaceBuilding("dummy", Random.Range(1,4), position);
        }
    }
}