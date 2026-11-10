using UnityEngine;

namespace Project.Scripts.Game.GameRoot.Services{
    //Глобальный сервис для всего проэкта (сервис аналитики и т.д.)
    public class SomeCommonService{

        public SomeCommonService(){
            Debug.Log(GetType().Name + " has been created.");
        }
    }
}