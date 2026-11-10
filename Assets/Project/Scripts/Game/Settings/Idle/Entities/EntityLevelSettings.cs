using UnityEngine;

namespace Project.Scripts.Game.Settings.Idle.Entities{
    [CreateAssetMenu(fileName = "EntityLevelSettings", menuName = "Game Settings/Idle/Entities/New Entity Level Settings")]
    public class EntityLevelSettings : ScriptableObject{
        [field:SerializeField] public int Level {get; private set;}
        [field:SerializeField] public string PrefabSkinPath {get; private set;}
    }
}