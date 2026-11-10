using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Game.Idle.Cheats{
    public class CheatPanelBinder : MonoBehaviour{
        private CheatPanelViewModel _viewModel;
        
        [SerializeField] private TMP_InputField CheatsInputField;
        [SerializeField] private Button ApplyButton;

        public void Bind(CheatPanelViewModel viewModel){
            _viewModel = viewModel;
        }

        private void OnEnable(){
            ApplyButton.onClick.AddListener(OnCheatClicked);
        }

        private void OnDisable(){
            ApplyButton.onClick.RemoveListener(OnCheatClicked);
        }

        public void OnCheatClicked(){
            _viewModel.HandleCheatApplying(CheatsInputField.text);
        }
    }
}