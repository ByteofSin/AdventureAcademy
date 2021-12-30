using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Byte.TileSystem;

namespace Byte.Grid {
    public class GridObject {
        //Reference to grid
        private LayeredGrid<GridObject> grid;

        //Grid Index of self
        private int x;
        private int y;
        private int layer;

        //Environment Information
        private TileScriptableObject tileData;
        private Tile tile;
        

        public GridObject(LayeredGrid<GridObject> grid, int x, int y, int layer){
            this.grid = grid;
            this.x = x;
            this.y = y;
            this.layer = layer;
        }
    }
}