using UnityEngine;
using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;


namespace Byte {
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
        private Vector3 GetWorldPosition(int xIndex, int yIndex, int layerIndex = 0){
            return new Vector3(xIndex, layerIndex, yIndex) * cellSize;
        }

        protected void GetIndex(Vector3 worldPosition, out int x, out int y, out int layer){
            x = Mathf.FloorToInt(worldPosition.x / cellSize);
            y = Mathf.FloorToInt(worldPosition.z / cellSize);
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
        public GridType GetCell(int x, int y, int layer = 0){
            //Check to make sure the cell exists
            if(ValidIndex(x, y, layer)){ 
                return grid[x,y,layer];
            } else {
                return default(GridType);
            }
        }

        public GridType GetCell(Vector3 position){
            int x, y, layer;
            GetIndex(position, out x, out y, out layer);
            return GetCell(x, y, layer);
        }

        public void SetCell(GridType data, int x, int y, int layer = 0){
            //Check to make sure the cell exists
            if(ValidIndex(x, y, layer)){
               grid[x, y, layer] = data;
            }
        }


        public void SetCell(GridType data, Vector3 position){
            int x, y, layer;
            GetIndex(position, out x, out y, out layer);
            SetCell(data, x, y, layer);
        }

        public List<GridType> GetAdjacentCells (int xIndex, int yIndex, int layerIndex){
            List<GridType> adjactenCells = new List<GridType>();

            for(int layer = layerIndex - 1; layer <= layerIndex + 1; layer++){
                for(int y = yIndex - 1; y <= yIndex + 1; y++){
                    for(int x = xIndex - 1; x <= xIndex + 1; x++){
                        if(ValidIndex(x, y, layer)){
                            adjactenCells.Add(GetCell(x, y, layer));
                        }
                    }
                }
            }

            return adjactenCells;
        }

        /* Utility Functions
        -------------------- */
        private bool ValidIndex(int x, int y, int layer){
            if(x >= 0 && x < GetWidth() && 
               y >= 0 && y < GetHeight() &&
               layer >= 0 && layer < GetLayers()){ 
                return true;
            } else {   
                return false;
            }
        }

        /* Debugging
        =============*/
        public void DrawDebugLines(float time = 60.0f){
            //Layer Loop
            for(int layer = 0; layer < GetLayers(); layer++){

                //Grid Loop
                for(int col = 0; col < GetHeight(); col++){
                    for(int row = 0; row < GetWidth(); row++){
                        Debug.DrawLine(GetWorldPosition(row, col, layer),
                                    GetWorldPosition(row, col + 1, layer),
                                    Color.white,time);
                        Debug.DrawLine(GetWorldPosition(row, col, layer),
                                    GetWorldPosition(row + 1, col, layer), 
                                    Color.white, time);
                    }
                }
                Debug.DrawLine(GetWorldPosition(0, GetHeight(), layer), 
                                GetWorldPosition(GetWidth(), GetHeight(), layer), 
                                Color.white, time);
                Debug.DrawLine(GetWorldPosition(GetWidth(), 0, layer), 
                                GetWorldPosition(GetWidth(), GetHeight(), layer), 
                                Color.white, time);
            }
          
        }
    }
}