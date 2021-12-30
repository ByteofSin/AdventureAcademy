using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Byte;

namespace Byte.TileSystem {
    public class TileMap : Byte.Grid.LayeredGrid<Tile> {
        public TileMap(int width = 10, int height = 10, int layers = 1, float cellSize = 1.0f){
            base.grid = new Tile[width, height, layers];
            base.cellSize = cellSize;
        }
    }
}
