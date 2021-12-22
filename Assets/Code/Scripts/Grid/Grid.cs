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
        public Grid(int width = 10, int height = 10, 
                    int layers = 1, float cellSize = 1.0f){
            this.cellSize = cellSize;
            InitializeArray(width, height, layers);
        }

        //Initializers
        protected void InitializeArray(int width, int height, int layers){
            //Construct the array
            grid = new GridType[width, height, layers];

            for(int l = 0; l < GetLayers(); l++){
                for(int x = 0; x < GetWidth(); x++){
                    for(int y = 0; y < GetHeight(); y++){
                        //gridArray[x,y] = new GridType();
                    }
                }
            }
            
            DrawDebugLines();
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


        private Vector3 GetWorldPosition(int x, int y, int z){
            return new Vector3(x,y,z) * cellSize;
        }

        /* Cell Information Getters
        ----------------------------- */
        //Gets the cell size
        public float GetCellSize(){
            return cellSize;
        }

        //Gets the total number of cells
        public int GetCellCount(){
            return grid.Length;
        }
        
        /* Data Getters 
        ---------------- */
        public GridType GetCell(int x, int y, int z){
            if(x >= 0 && x < GetWidth() && 
               y >= 0 && y < GetHeight() &&
               z >= 0 && z < GetLayers()){ 
                return grid[x,y,z];
            } else {
                return default(GridType);
            }
        }

        public GridType GetCell(Vector3 cellIndex){
            return GetCell((int)cellIndex.x, (int)cellIndex.y, (int)cellIndex.z);
        }

        /* Debugging
        =============*/
        public void DrawDebugLines(){
            for(int l = 0; l < GetLayers(); l++){
                for(int y = 0; y < GetHeight(); y++){
                    for(int x = 0; x < GetWidth(); x++){
                        Debug.DrawLine(GetWorldPosition(x,l,y),
                                    GetWorldPosition(x, l, y + 1),
                                    Color.white, 100.0f);
                        Debug.DrawLine(GetWorldPosition(x, l, y),
                                    GetWorldPosition(x + 1, l, y), 
                                    Color.white, 100.0f);
                    }
                }
                Debug.DrawLine(GetWorldPosition(0, l, GetHeight()), 
                                GetWorldPosition(GetWidth(), l, GetHeight()), 
                                Color.white, 100.0f);
                Debug.DrawLine(GetWorldPosition(GetWidth(), l, 0), 
                                GetWorldPosition(GetWidth(), l, GetHeight()), 
                                Color.white, 100.0f);
            }
          
        }
    }
}