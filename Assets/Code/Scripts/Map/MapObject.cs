using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Byte.TileSystem;
using Byte.Grid;

namespace Byte.Map {
    public class MapObject {
        //Reference to grid
        private LayeredGrid<MapObject> grid;

        //Grid Index of self
        private int x;
        private int y;
        private int layer;

        //Environment Information
        private TileScriptableObject tileData;
        private Tile tile;
        

        public MapObject(LayeredGrid<MapObject> grid, int x, int y, int layer){
            this.grid = grid;
            this.x = x;
            this.y = y;
            this.layer = layer;
        }
    }
}