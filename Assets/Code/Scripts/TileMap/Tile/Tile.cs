using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Byte.TileSystem {
    public class Tile {
        [SerializeField]
        private TileType tile;

        public int xIndex;
        public int yIndex;
        public int layerIndex;

    }
}