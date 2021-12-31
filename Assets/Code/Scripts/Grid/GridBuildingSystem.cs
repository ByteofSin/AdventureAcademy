using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Byte.Grid;
using Byte.Utilities;

namespace Byte.Grid {
    public class GridBuildingSystem : MonoBehaviour {
        private LayeredGrid<GridObject> grid;
        public Transform testTransform;
        
        public void Awake(){
            int gridWidth = 10;
            int gridHeight = 10;
            int gridLayers = 1;

            float cellSize = 1;
            float layerSize = 3;
            this.grid = new LayeredGrid<GridObject>(
                gridWidth, gridHeight, gridLayers,
                cellSize, layerSize,
                (LayeredGrid<GridObject> grid, int x, int y, int layer) => new GridObject(
                    grid,
                    x, y, layer
                ));
                
            grid.DrawDebugLines(30f);
        }

        public void Update(){
            if(Input.GetMouseButtonDown(0)){
                Vector3 transformPosition = grid.GetWorldToGrid(MouseWorldPosition.GetMouseWorldPosition());

                Instantiate(testTransform, transformPosition, Quaternion.identity);
                
            }
        }
        
    }
    
}