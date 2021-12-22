using UnityEngine;
using System;
using Sirenix.OdinInspector;

namespace Byte.Map {
    [System.Serializable]
    public class Grid <GridType> {
        /* Variables
        ============= */
        private int width = 10;
        private int height = 10;
        private float cellSize = 1.0f;
        private GridType[,] gridArray; //x by y. so grid[2,2] is equal to (2,2)
        
        /* Constructors
        ================ */
        public Grid(){
            InitializeArray(width, height);
        }

        public Grid(int width = 10, int height = 10){
            //Set variables to match
            this.width = width;
            this.height = height;

            InitializeArray(width,height);
        }

        //Initializers
        protected void InitializeArray(int width, int height){
            //Construct the array
            gridArray = new GridType[width, height];

            for(int x = 0; x < gridArray.GetLength(0); x++){
                for(int y = 0; y < gridArray.GetLength(1); y++){
                    //gridArray[x,y] = new GridType();
                }
            }
            
            DrawDebugLines();
               
        }

        /* Getters and Setters
        ======================= */
        /* Dimension Getters 
        --------------------- */
        public int GetWidth(){
            return width;
        }

        public int GetHeight(){
            return height;
        }

        private Vector3 GetWorldPosition(int x, int y){
            return new Vector3(x,0,y) * cellSize;
        }

        /* Cell Information Getters
        ----------------------------- */
        //Gets the cell size
        public float GetCellSize(){
            return cellSize;
        }

        //Gets the total number of cells
        public int GetCellCount(){
            return gridArray.Length;
        }
        
        /* Data Getters 
        ---------------- */
        public GridType GetCell(int x, int y){
            if(x >= 0 && x < width && y >= 0 && y < height){ 
                return gridArray[x,y];
            } else {
                return default(GridType);
            }
        }

        public GridType GetCell(Vector3 cellIndex){
            return GetCell((int)cellIndex.x, (int)cellIndex.y);
        }

        /* Debugging
        =============*/
        private void DrawDebugLines(){
            for(int y = 0; y < gridArray.GetLength(1); y++){
                for(int x = 0; x < gridArray.GetLength(0); x++){
                    Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x, y + 1), Color.white, 100.0f);
                    Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x + 1, y), Color.white, 100.0f);
                    
                }            
            }

            Debug.DrawLine(GetWorldPosition(0,height), GetWorldPosition(width, height), Color.white, 100.0f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100.0f);
        }
    }
}