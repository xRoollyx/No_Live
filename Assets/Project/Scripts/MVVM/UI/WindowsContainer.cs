using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.MVVM.UI{
    public class WindowsContainer : MonoBehaviour{
        [SerializeField] private Transform ScreensContainer;
        [SerializeField] private Transform PopupsContainer;

        private readonly Dictionary<WindowViewModel, IWindowBinder> _openedPopupsBinders = new();
        private IWindowBinder _openedScreenBinder;

        public void OpenPopup(WindowViewModel viewModel) {
            var prefabPath = GetPrefabPath(viewModel);
            var prefab = Resources.Load(prefabPath) as GameObject;
            var createdPopup = Instantiate(prefab, PopupsContainer);
            var binder = createdPopup.GetComponent<IWindowBinder>();
            
            binder.Bind(viewModel);
            _openedPopupsBinders.Add(viewModel, binder);
        }

        public void ClosePopup(WindowViewModel viewModel) {
            var binder = _openedPopupsBinders[viewModel];
            binder?.Close();
            _openedPopupsBinders.Remove(viewModel);
        }

        public void OpenScreen(WindowViewModel viewModel){
            if (viewModel == null){
                return;
            }
            _openedScreenBinder?.Close();
            
            var prefabPath = GetPrefabPath(viewModel);
            var prefab = Resources.Load(prefabPath) as GameObject;
            var createdScreen = Instantiate(prefab, ScreensContainer);
            var binder = createdScreen.GetComponent<IWindowBinder>();
            
            binder.Bind(viewModel);
            _openedScreenBinder = binder;
        }

        private static string GetPrefabPath( WindowViewModel viewModel){
            return $"Prefabs/UI/{viewModel.Id}";
        }
    }
}