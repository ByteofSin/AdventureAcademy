using UnityEngine;
using System;

namespace Byte.Grid {
    [System.Serializable]
    public class Grid2D {
        [Header("Dimensions")]
        [SerializeField] private int height = 10;
        [SerializeField] private int width = 10;
        private int[,] gridArray; //x by y. so grid[2,2] is equal to (2,2)
        

        public Grid2D(){
            gridArray = new int[this.width, this.height];
        }

        public Grid2D(int width = 10, int height = 10){
            this.width = width;
            this.height = height;
            gridArray = new int[width, height];
        }
        //Dimension Getters
        public Vector2 GetDimensions(){
            return new Vector2(GetWidth(), GetHeight());
        }
        public int GetWidth(){
            return width;
        }

        public int GetHeight(){
            return height;
        }

        //Size Getter
        public int GetCellCount(){
            return gridArray.Length;
        }

        //Get an index
        public int GetCell(int x, int y){
            return gridArray[x,y];
        }
    }
}