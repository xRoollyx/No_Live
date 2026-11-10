using UnityEngine;

namespace Project.Scripts.Game.Settings{
    [CreateAssetMenu(fileName = "ApplicationSettings", menuName = "Game Settings/New Application Settings")]
    public class ApplicationSettings : ScriptableObject{
        public int MusicVolume;
        public int SoundVolume;
        public string Difficulty;
    }
}