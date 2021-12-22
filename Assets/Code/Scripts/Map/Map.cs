/*
Stores and handles map information
*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

using Byte.Map.Generator;
using Byte.Grid;

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
        private MapGeneratorBase generator;

        private Byte.Grid.Grid<MapObject> grid;

        private void Awake(){
            InitilizeGrid();
        }

        private void InitilizeGrid(){
            grid = new Byte.Grid.Grid<MapObject>(width, height, layers, cellScale);
        }

        [Button("Display Debug Grid")]
        private void DisplayDebugGrid(){
            InitilizeGrid();
            grid.DrawDebugLines();
        }
    }
}