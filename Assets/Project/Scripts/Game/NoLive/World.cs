using UnityEngine;

namespace Project{
    public class World : MonoBehaviour{
        [SerializeField] private GameObject tilePrefab;
        private Vector2Int _worldSize;
        private Tile[,] _tiles;

        public void WorldCreate(Vector2Int worldSize){
            _worldSize = worldSize;
            _tiles = new Tile[worldSize.x,worldSize.y];

            for (int x = 0; x < worldSize.x; x++){
                for (int y = 0; y < worldSize.y; y++){
                    var prefab= Instantiate(tilePrefab, new Vector3(x,y,0), Quaternion.identity);
                    TileVisual tileVisual = prefab.GetComponent<TileVisual>();
                    var tile = new Tile(tileVisual);
                    _tiles[x,y] = tile;
                }
            }
        }

        public Tile GetTile(Vector2Int pos){
            
            return _tiles[pos.x,pos.y];
        }
    }
}