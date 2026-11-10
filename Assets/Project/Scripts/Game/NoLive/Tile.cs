using UnityEngine;

namespace Project{
    public class Tile{
        public TileType type;
        private TileVisual _tileVisual;

        public Tile(TileVisual tileVisual){
            _tileVisual = tileVisual;
            type = TileType.Empty;
            _tileVisual.GetComponentInChildren<Renderer>().material.color = Random.ColorHSV();
        }
    }
}