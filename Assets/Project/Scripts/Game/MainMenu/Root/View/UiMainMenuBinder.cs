using R3;
using UnityEngine;

namespace Project.Scripts.MainMenu.Root.View{
    public class UiMainMenuBinder : MonoBehaviour{
        private Subject<Unit> _goToIdleButtonClick;
        public void HandleGoToIdleButtonClicked(){
            _goToIdleButtonClick?.OnNext(Unit.Default);
        }

        public void Bind(Subject<Unit> exitSceneSignalSubj){
            _goToIdleButtonClick = exitSceneSignalSubj;
        }
    }
}