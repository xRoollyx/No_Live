using Project.Scripts.DI;

namespace Project.Scripts.MVVM.UI{
    public abstract class UiManager{
        protected readonly DiContainer Container;
        
        protected UiManager(DiContainer container){
            Container = container;
        }
    }
}