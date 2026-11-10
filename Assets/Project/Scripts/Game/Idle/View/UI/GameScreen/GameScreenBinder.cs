using System;
using Project.Scripts.MVVM.UI;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace Project.Scripts.Game.Idle.View.UI.GameScreen{
    public class GameScreenBinder: WindowBinder<GameScreenViewModel>{
        [SerializeField] private Button OpenGameplayScreenButton;
        [SerializeField] private Button CreateBuildingButton;
        [SerializeField] private TextMeshProUGUI _textCoins;

        private void OnEnable(){
            OpenGameplayScreenButton.onClick.AddListener(OnOpenGameplayScreenButtonClicked);
            CreateBuildingButton.onClick.AddListener(OnCreateBuildingButtonClicked);
        }

        private void OnDisable(){
            OpenGameplayScreenButton.onClick.RemoveListener(OnOpenGameplayScreenButtonClicked);
            CreateBuildingButton.onClick.RemoveListener(OnCreateBuildingButtonClicked);
        }

        private void OnOpenGameplayScreenButtonClicked(){
            ViewModel.RequestOpenGameplayScreen();
        }

        private void OnCreateBuildingButtonClicked(){
            ViewModel.RequestCreateBuilding();
        }

        private void Start(){
            ViewModel.Coins.Subscribe(UpdateCoinsText);
        }

        private void UpdateCoinsText(int coins){
            _textCoins.text = coins.ToString();
        }

        
    }
}