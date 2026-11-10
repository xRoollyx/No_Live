using UnityEngine;

namespace Project.Scripts.Game.Settings.Idle.Entities.Buildings{
    [CreateAssetMenu(fileName = "BuildingLevelSettings", menuName = "Game Settings/Idle/Entities/Buildings/New Building Level Settings")]
    public class BuildingLevelSettings: EntityLevelSettings{
        [field:SerializeField] public double BaseIncome{ get; private set; }
    }
}