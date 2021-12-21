namespace Byte.Grid {
    public class Grid2D {
        private int[,] gridArray; //x by y. so grid[2,2] is equal to (2,2)
        public Grid2D(int width = 10, int height = 10){
            gridArray = new int[width, height];
        }

        public int GetWidth(){
            return gridArray.Length;
        }

        public int GetHeight(int row = 0){
            return gridArray.GetLength(row);
        }

        public int Get(int x, int y){
            return gridArray[x,y];
        }
    }
}