using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Game.Settings.Idle.Maps{
    [CreateAssetMenu(fileName = "MapsSettings", menuName = "Game Settings/Idle/Maps/New Maps Settings")]
    public class MapsSettings:  ScriptableObject{
        public List<MapSettings> Maps;
    }
}