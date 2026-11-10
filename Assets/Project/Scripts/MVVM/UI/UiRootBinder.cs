using System;
using ObservableCollections;
using R3;
using UnityEngine;

namespace Project.Scripts.MVVM.UI{
    public class UiRootBinder : MonoBehaviour{
        [SerializeField] private WindowsContainer WindowsContainer;
        private  readonly CompositeDisposable _subscriptions = new();
        
        public void Bind(UiRootViewModel viewModel){
            _subscriptions.Add(viewModel.OpenedScreen.Subscribe(newScreenViewModel => {
                WindowsContainer.OpenScreen(newScreenViewModel);
            }));

            foreach (var openedPopup in viewModel.OpenedPopups){
                WindowsContainer.OpenPopup(openedPopup);
            }
            
            _subscriptions.Add(viewModel.OpenedPopups.ObserveAdd().Subscribe(e => {
                WindowsContainer.OpenPopup(e.Value);
            }));

            _subscriptions.Add(viewModel.OpenedPopups.ObserveRemove().Subscribe(e => {
                WindowsContainer.ClosePopup(e.Value);
            }));
            
            OnBind(viewModel);
        }

        protected virtual void OnBind(UiRootViewModel rootViewModel){
            
        }

        private void OnDestroy(){
            _subscriptions.Dispose();
        }
    }
}