using UnityEngine;

namespace Project.Scripts.Game.Settings.Idle.Maps{
    [CreateAssetMenu(fileName = "MapSettings", menuName = "Game Settings/Idle/Maps/New Map Settings")]
    public class MapSettings : ScriptableObject{
        public int MapId;
        public MapInitialStateSettings  InitialStateSettings;
    }
}