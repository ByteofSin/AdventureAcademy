using System;

using Sirenix.OdinInspector;

using Byte.Grid;

//using UnityEngine;

namespace Byte.Procedural {
    [System.Serializable]
    public class CelularAutomata {
        private LayeredGrid<bool> grid;

        private int height = 10;
        private int width = 10;
        private int layers = 1;

        private float initialChance = 0.5f;

        private int underpopulation = 2;
        private int overpopulation = 3;
        private int birth = 3;

        public CelularAutomata(){
            grid = new LayeredGrid<bool>(this.width, this.height, this.layers);
        }

        public CelularAutomata(int width, int height, int layers){
            grid = new LayeredGrid<bool>(width, height, layers);
        }

        public void InitliazeGrid(){
            for(int layer = 0; layer < grid.GetLayers(); layer++){
                for(int y = 0; y < grid.GetHeight(); y++){
                    for(int x = 0; x < grid.GetWidth(); x++){
                        grid.SetCell(
                            ((UnityEngine.Random.Range(0.0f, 1.0f) < initialChance) ? true : false),
                            x, y, layer
                        );
                    }
                }
            }
        }

        public void Iterate(){
            Byte.Grid.LayeredGrid<bool> newGrid = new Byte.Grid.LayeredGrid<bool>(width, height, layers);
            
            for(int layer = 0; layer < grid.GetLayers(); layer++){  
                for(int y = 0; y < grid.GetHeight(); y++){
                    for(int x = 0; x < grid.GetWidth(); x++){
                        newGrid.SetCell(
                            GetCellResult(x, y, layer),
                            x, y, layer
                        );
                    }
                }
            }

            grid = newGrid;
        }

        public bool GetCellResult(int x, int y, int layer){
            int count = grid.GetAdjacentCells(x, y, layer).Count;

            if(grid.GetCell(x, y, layer)){ //Cell is true
                if(count <= underpopulation || count >= overpopulation){
                    return false;
                } else {
                    return true;
                }
            } else { //Cell is false
                if(count >= birth){
                    return true;
                } else {
                    return false;
                }
            }
        }
    }
}