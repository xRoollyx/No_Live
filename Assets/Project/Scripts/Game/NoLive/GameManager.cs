using UnityEngine;

namespace Project{
    public class GameManager: MonoBehaviour{
        [SerializeField] private Vector2Int worldSize;
        
        public static GameManager Instance;
        
        public World world;

        private void Awake(){
            Instance = this;
            world.WorldCreate(worldSize);
        }
    }
}