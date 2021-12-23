/*
Central location to store and handle components of map
*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

using Byte.TileSystem.Generator;
using Tile = Byte.TileSystem.Tile;
using Grid = Byte.Grid<Byte.TileSystem.Tile>;

namespace Byte.Map {
    [System.Serializable]
    public class Map : MonoBehaviour {
        [TitleGroup("Dimensions")]
        [HorizontalGroup("Dimensions/BoundGroup")]
        [VerticalGroup("Dimensions/BoundGroup/Width"),
            LabelWidth(50)]
        [SerializeField]
        private int width = 10;
        
        [VerticalGroup("Dimensions/BoundGroup/Height"),  
            LabelWidth(50)]
        [SerializeField]
        private int height = 10;

        [SerializeField]
        private int layers = 1;

        [SerializeField]
        private float cellScale = 1.0f;

        [TitleGroup("MapGenerator")]
        [SerializeField]
        private TileMapGenerator generator;

        private Grid<Tile> grid;

        [FoldoutGroup("Debug Options")]
        [MinValue(0.1)]
        [SerializeField]
        private float time = 30.0f;

        private void Awake(){
            InitilizeGrid();
            InitializeTileMap();
        }

        private void InitilizeGrid(){
            grid = new Grid<Tile>(width, height, layers, cellScale);
        }

        private void InitializeTileMap(){

        }

        private void RenderTileMap(){

        }

        /* Debug utilities
        ---------------------*/
        [Button("Display Debug Grid")]
        private void DisplayDebugGrid(){
            InitilizeGrid();
            grid.DrawDebugLines(time);
        }
    }
}