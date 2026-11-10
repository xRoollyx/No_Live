using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.Game.Idle.View.BuildingsView{
    public class BuildingBinder :MonoBehaviour{
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        private float _timer = 1f;
        private float _minedCoins;
        private float _coinsPerSecond = 0.5f;
        private BuildingViewModel _viewModel;
        public void Bind(BuildingViewModel viewModel){
            _viewModel = viewModel;
            var position = new Vector3Int(viewModel.Position.CurrentValue.x,0,viewModel.Position.CurrentValue.y);
            transform.position = position;
            UpdateText();
        }

        private void Update(){
            _timer -= Time.deltaTime;
            if (_timer < 0){
                _timer += 1f;
                _minedCoins += _coinsPerSecond;
                UpdateText();
            }
        }

        public void CollectCoins(){
            _viewModel.CollectCoinsClicked((int)_minedCoins);
            _minedCoins -= (int)_minedCoins;
            UpdateText();
        }
        
        private void UpdateText(){
            if (_textMeshPro){
                int coins = (int)_minedCoins;
                _textMeshPro.text = coins.ToString();
            }
        }
    }
}