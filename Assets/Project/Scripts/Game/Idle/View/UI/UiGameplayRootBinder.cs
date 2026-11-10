using Project.Scripts.Game.Idle.Cheats;
using Project.Scripts.MVVM.UI;
using UnityEngine;

namespace Project.Scripts.Game.Idle.View.UI{
    public class UiGameplayRootBinder : UiRootBinder{
        [SerializeField] private CheatPanelBinder  CheatPanelBinder;
        protected override void OnBind(UiRootViewModel rootViewModel){
            base.OnBind(rootViewModel);
            var viewModel = rootViewModel as UiGameplayRootViewModel;
            
            CheatPanelBinder.Bind(viewModel?.CheatPanelViewModel);
        }
    }
}