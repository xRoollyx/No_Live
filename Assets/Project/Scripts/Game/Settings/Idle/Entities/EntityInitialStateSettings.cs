using System;
using Project.Scripts.Game.GameState.Entities;
using UnityEngine;

namespace Project.Scripts.Game.Settings.Idle.Entities{
    [Serializable]
    public class EntityInitialStateSettings{
        [field:SerializeField] public EntityType EntityType {get; private set;}
        [field:SerializeField] public string ConfigId {get; private set;}
        [field:SerializeField] public int Level {get; private set;}
        [field:SerializeField] public Vector2Int InitialPosition {get; private set;}
    }
}