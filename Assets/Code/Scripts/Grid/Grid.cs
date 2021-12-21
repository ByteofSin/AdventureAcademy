using UnityEngine;
using System;

namespace Byte {
    [System.Serializable]
    public class Grid {
        [Header("Dimensions")]
        [SerializeField] private int height = 10;
        [SerializeField] private int width = 10;
        private int[,] gridArray; //x by y. so grid[2,2] is equal to (2,2)
        

        public Grid(){
            gridArray = new int[this.width, this.height];
        }

        public Grid(int width = 10, int height = 10){
            this.width = width;
            this.height = height;
            gridArray = new int[width, height];
        }

        //Dimension Getters
        public Vector2 GetDimensions(){
            return new Vector2(GetWidth(), GetHeight());
        }
        public int GetWidth(){
            return gridArray.Length;
            return width;
        }

        public int GetHeight(){
            return height;
        }

        //Size Getter
        public int GetCellCount(){
            return gridArray.Length;
        }

        public int GetCell(int x, int y){
            return gridArray[x,y];
        }
    }
}