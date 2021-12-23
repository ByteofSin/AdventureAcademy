using UnityEngine;
using System;
using Sirenix.OdinInspector;

namespace Byte.Grid {
    [System.Serializable]
    public class Grid <GridType> {
        /* Variables
        ============= 
        x is used for rows
        y is used for columns 
            so (x,y) is valid for a unit
        z is used for layer (so up and down)
        */
        
        private GridType[,,] grid;
        private float cellSize;

        /* Constructors
        ================ */
        public Grid(int width = 10, int height = 10, int layers = 1, float cellSize = 1.0f){
            this.cellSize = cellSize;
            InitializeArray(width, height, layers);
        }

        //Initialize the 
        protected void InitializeArray(int width, int height, int layers){
            //Construct the array
            grid = new GridType[width, height, layers];

            //Loop through all cells and put an initial amount
            for(int l = 0; l < GetLayers(); l++){
                for(int x = 0; x < GetWidth(); x++){
                    for(int y = 0; y < GetHeight(); y++){
                        //gridArray[x,y] = new GridType();
                    }
                }
            }
        }

        /* Getters and Setters
        ======================= */
        /* Dimension Getters 
        --------------------- */
        public int GetWidth(){
            return grid.GetLength(0);
        }

        public int GetHeight(){
            return grid.GetLength(1);
        }

        public int GetLayers(){
            return grid.GetLength(2);
        }

        //Converts from graph to world position
        //X is the same but z is column and layers is y.
        private Vector3 GetWorldPosition(int rowIndex, int colIndex, int layerIndex = 0){
            return new Vector3(rowIndex, layerIndex, colIndex) * cellSize;
        }

        private void GetIndex(Vector3 worldPosition, out int row, out int col, out int layer){
            row = Mathf.FloorToInt(worldPosition.x / cellSize);
            col = Mathf.FloorToInt(worldPosition.z / cellSize);
            layer = Mathf.FloorToInt(worldPosition.y / cellSize);
        }

        /* Cell Meta Information Getters
        ----------------------------- */
        //Gets the cell size
        public float GetCellSize(){
            return cellSize;
        }

        //Gets the total number of cells
        public int GetCellCount(){
            return grid.Length;
        }
        
        /* Cell Getters and setters
            Uses int inputs to get by index or a vector 3 to get via world position
        ------------------------------------------------------------------------------*/
        public GridType GetCell(int x, int y, int z = 0){
            //Check to make sure the cell exists
            if(x >= 0 && x < GetWidth() && 
               y >= 0 && y < GetHeight() &&
               z >= 0 && z < GetLayers()){ 
                return grid[x,y,z];
            } else {
                return default(GridType);
            }
        }

        public GridType GetCell(Vector3 position){
            int row, col, layer;
            GetIndex(position, out row, out col, out layer);
            return GetCell(row, col, layer);
        }

        public void SetCell(GridType data, int row, int col, int layer = 0){
            //Check to make sure the cell exists
            if(row >= 0 && row < GetWidth() && 
               col >= 0 && col < GetHeight() &&
               layer >= 0 && layer < GetLayers()){ 
               grid[row, layer, col] = data;
            }
        }


        public void SetCell(GridType data, Vector3 position){
            int row, col, layer;
            GetIndex(position, out row, out col, out layer);
            SetCell(data, row, col, layer);
        }

        /* Debugging
        =============*/
        public void DrawDebugLines(){
            //Layer Loop
            for(int layer = 0; layer < GetLayers(); layer++){

                //Grid Loop
                for(int col = 0; col < GetHeight(); col++){
                    for(int row = 0; row < GetWidth(); row++){
                        Debug.DrawLine(GetWorldPosition(row, col, layer),
                                    GetWorldPosition(row, col + 1, layer),
                                    Color.white, 100.0f);
                        Debug.DrawLine(GetWorldPosition(row, col, layer),
                                    GetWorldPosition(row + 1, col, layer), 
                                    Color.white, 100.0f);
                    }
                }
                Debug.DrawLine(GetWorldPosition(0, GetHeight(), layer), 
                                GetWorldPosition(GetWidth(), GetHeight(), layer), 
                                Color.white, 100.0f);
                Debug.DrawLine(GetWorldPosition(GetWidth(), 0, layer), 
                                GetWorldPosition(GetWidth(), GetHeight(), layer), 
                                Color.white, 100.0f);
            }
          
        }
    }
}