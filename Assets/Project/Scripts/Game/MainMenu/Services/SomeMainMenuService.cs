using Project.Scripts.Game.GameRoot.Services;
using UnityEngine;

namespace Project.Scripts.MainMenu.Services{
    public class SomeMainMenuService{
        private readonly SomeCommonService _commonService;

        public SomeMainMenuService(SomeCommonService commonService){
            _commonService = commonService;
            Debug.Log(GetType().Name + " started");
        }
    }
}