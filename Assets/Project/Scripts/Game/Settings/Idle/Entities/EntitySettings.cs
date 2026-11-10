using System.Collections.Generic;
using Project.Scripts.Game.GameState.Entities;
using UnityEngine;

namespace Project.Scripts.Game.Settings.Idle.Entities{
    public abstract class EntitySettings<T> : ScriptableObject where T : EntityLevelSettings{
        [field: SerializeField] public EntityType EntityType { get; private set; }
        [field: SerializeField] public string ConfigId { get; private set; }
        [field: SerializeField] public string TitleLid { get; private set; }
        [field: SerializeField] public string DescriptionLid { get; private set; }
        [field: SerializeField] public string PrefabPath { get; private set; }
        [field: SerializeField] public List<T> Levels  { get; private set; }
    }

    [CreateAssetMenu(fileName = "EntitySettings", menuName = "Game Settings/Idle/Entities/New Entity Settings")]
    public class EntitySettings : EntitySettings<EntityLevelSettings>{
        
    }
}