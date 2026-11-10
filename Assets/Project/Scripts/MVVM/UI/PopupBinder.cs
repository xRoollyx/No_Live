using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.MVVM.UI{
    public abstract class PopupBinder<T> : WindowBinder<T> where T : WindowViewModel{
        [SerializeField] private Button BtnClose;
        [SerializeField] private Button BtnCloseAlt;

        protected virtual void Start(){
            BtnClose?.onClick.AddListener(OnCloseButtonClick);
            BtnCloseAlt?.onClick.AddListener(OnCloseButtonClick);
        }

        protected virtual void OnDisable(){
            BtnClose?.onClick.RemoveListener(OnCloseButtonClick);
            BtnCloseAlt?.onClick.RemoveListener(OnCloseButtonClick);
        }

        protected virtual void OnCloseButtonClick(){
            ViewModel.RequestClose();
        }
    }
}