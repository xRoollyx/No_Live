using UnityEngine;

namespace Project.Scripts.MVVM.UI{
    public abstract class WindowBinder<T> : MonoBehaviour, IWindowBinder where T: WindowViewModel{
        protected T ViewModel;

        public void Bind(WindowViewModel viewModel){
            ViewModel = viewModel as T;
            OnBind(ViewModel);
        }

        public virtual void Close(){
            // здесь мы сначала будем уничтожать, а потом можно делать анимацию на закрытие
            
            Destroy(gameObject);
        }
        
        protected virtual void OnBind(T viewModel){}
    }
}