using Project.Scripts.Game.Settings.Idle.Entities;
using Project.Scripts.Game.Settings.Idle.Entities.Buildings;
using Project.Scripts.Game.Settings.Idle.Maps;
using UnityEngine;

namespace Project.Scripts.Game.Settings{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings/New Game Settings")]
    public class GameSettings: ScriptableObject{
        public EntitiesSettings EntitiesSettings;
        public MapsSettings MapsSettings;
    }
}