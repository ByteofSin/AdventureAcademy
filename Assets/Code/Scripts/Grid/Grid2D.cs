using UnityEngine;
using System;
using Sirenix.OdinInspector;

namespace Byte.Grid {
    [System.Serializable]
    public class Grid2D {
        [TitleGroup("Dimensions")]
        [HorizontalGroup("Dimensions/Values"), LabelWidth(0)]
        [MinValue(1)]
        [SerializeField] private int width = 10;

        
        [TitleGroup("Dimensions")]
        [HorizontalGroup("Dimensions/Values")]
        [MinValue(1)]
        [SerializeField] private int height = 10;

        [TitleGroup("Dimensions")]
        [HorizontalGroup("Dimensions/Size")]
        [MinValue(0)]
        [SerializeField] private float cellSize = 1.0f;

        [TitleGroup("Options")]
        [SerializeField] private bool debug = true;

        [TitleGroup("Options")]
        [EnableIf("debug")]
        [ShowIf("debug")]
        [SerializeField] private bool drawLines = true;

        //Private Variables
        private int[,] gridArray; //x by y. so grid[2,2] is equal to (2,2)
        
        //Constructors
        public Grid2D(){
            InitializeArray(width, height);
        }

        public Grid2D(int width = 10, int height = 10){
            //Set variables to match
            this.width = width;
            this.height = height;

            InitializeArray(width,height);
        }

        //Initializers
        protected void InitializeArray(int width, int height){
            //Construct the array
            gridArray = new int[width, height];

            for(int x = 0; x < gridArray.GetLength(0); x++){
                for(int y = 0; y < gridArray.GetLength(1); y++){
                    gridArray[x,y] = 0;
                }
            }

            if(debug){
                if(drawLines){
                    DrawDebugLines();
                }
            }
        }

        //Getters
        //Dimension Getters
        public int GetWidth(){
            return width;
        }

        public int GetHeight(){
            return height;
        }

        //Cell size getter
        public float GetCellSize(){
            return cellSize;
        }

        //Cell count Getter
        public int GetCellCount(){
            return gridArray.Length;
        }

        //Gets cell position compared to world space
        private Vector3 GetWorldPosition(int x, int y){
            return new Vector3(x,0,y) * cellSize;
        }

        //Getter for specific cell
        public int GetCell(int x, int y){
            return gridArray[x,y];
        }

        //Debugging
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