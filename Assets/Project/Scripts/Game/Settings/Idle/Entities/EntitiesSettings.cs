using System.Collections.Generic;
using Project.Scripts.Game.Settings.Idle.Entities.Buildings;
using UnityEngine;

namespace Project.Scripts.Game.Settings.Idle.Entities{
    [CreateAssetMenu(fileName = "EntitiesSettings", menuName = "Game Settings/Idle/Entities/New Entities Settings")]
    public class EntitiesSettings: ScriptableObject{
        [field:SerializeField] public List<BuildingSettings> Buildings{ get; private set; }
    }
}