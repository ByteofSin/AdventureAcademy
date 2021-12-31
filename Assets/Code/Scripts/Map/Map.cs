/*
Central location to store and handle components of map
*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

using Byte.TileSystem;
using Byte.TileSystem.Generator;
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

        //private LayeredGrid grid;

        [FoldoutGroup("Debug Options")]
        [MinValue(0.1)]
        [SerializeField]
        private float gridDisplayTime = 30.0f;

        private void Awake(){
            InitializeTileMap();
        }

        

        private void InitializeTileMap(){
            //tilemap = new TileMap(width, height, layers, cellScale);
        }


        /* Debug utilities
        ---------------------*/
        [Button("Display Debug Grid")]
        private void DisplayDebugGrid(){
            InitializeTileMap();
            //tilemap.DrawDebugLines(gridDisplayTime);
        }
    }
}