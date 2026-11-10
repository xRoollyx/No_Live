using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Project{
    public class Bot{
        private Direction _botDirection;
        private Vector2Int _position;
        private int _energy;
        private readonly int[] _gen;
        private int _indexGen;

        public Bot(int[] gen, int energy, Vector2Int position){
            _gen = gen;
            _energy = energy;
            _position = position;
        }

        public void Tick(){
            _energy--;
            if (_energy <= 0){
                Die();
            }

            var action = _gen[_indexGen];
            Direction direction;
            Tile tile;

            switch (action){
                case >= 0 and <= 7:
                    direction = _botDirection.NewDirection(action);
                    tile = GetTileDirection(GetDirection(direction));
                    if (tile.type == TileType.Empty){
                        _botDirection = direction;
                        _position += GetDirection(direction);
                        action += 5;
                    }
                    break;
                case >= 8 and <= 15:
                    break;
            }
            
            
        }

        private void Die(){
        }

       
        private Tile GetTileDirection(Vector2Int direction){
            return GameManager.Instance.world.GetTile(_position + direction);
        }

        private Vector2Int GetDirection(Direction direction){
            switch (direction){
                case Direction.N:
                    return new Vector2Int(0,1);
                case Direction.Ne:
                    return new Vector2Int(1,1);
                case Direction.E:
                    return new Vector2Int(1,0);
                case Direction.Se:
                    return new Vector2Int(1,-1);
                case Direction.S:
                    return new Vector2Int(0,-1);
                case Direction.Sw:
                    return new Vector2Int(-1,-1);
                case Direction.W:
                    return new Vector2Int(-1,0);
                case Direction.Nw:
                    return new Vector2Int(-1,1);
            }
            return Vector2Int.zero;
        }
    }
}