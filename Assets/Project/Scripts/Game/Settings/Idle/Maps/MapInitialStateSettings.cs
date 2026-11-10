using System;
using System.Collections.Generic;
using Project.Scripts.Game.Settings.Idle.Entities;
using Project.Scripts.Game.Settings.Idle.Entities.Buildings;

namespace Project.Scripts.Game.Settings.Idle.Maps{
    [Serializable]
    public class MapInitialStateSettings {
        public List<EntityInitialStateSettings>  Entities;
    }
}