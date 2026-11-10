using System;
using Project.Scripts.MVVM.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Game.Idle.View.UI.ScreenGameplay{
    public class ScreenGameplayBinder : WindowBinder<ScreenGameplayViewModel>{
        [SerializeField] private Button BtnPopupA;
        [SerializeField] private Button BtnPopupB;
        [SerializeField] private Button BtnGoToMainMenu;
        [SerializeField] private Button BtnStartGame;

        private void OnEnable(){
            BtnPopupA.onClick.AddListener(OnPopupAButtonClicked);
            BtnPopupB.onClick.AddListener(OnPopupBButtonClicked);
            BtnGoToMainMenu.onClick.AddListener(OnGoToMainMenuButtonClicked);
            BtnStartGame.onClick.AddListener(OnStartGameButtonClicked);
        }

        private void OnDisable(){
            BtnPopupA.onClick.RemoveListener(OnPopupAButtonClicked);
            BtnPopupB.onClick.RemoveListener(OnPopupBButtonClicked);
            BtnGoToMainMenu.onClick.RemoveListener(OnGoToMainMenuButtonClicked);
            BtnStartGame.onClick.RemoveListener(OnStartGameButtonClicked);
        }

        private void OnPopupAButtonClicked(){
            ViewModel.RequestOpenPopupA();
        }
        private void OnPopupBButtonClicked(){
            ViewModel.RequestOpenPopupB();
        }
        private void OnGoToMainMenuButtonClicked(){
            ViewModel.RequestGoToMainMenu();
        }

        private void OnStartGameButtonClicked(){
            ViewModel.RequestStartGame();
        }
    }
}