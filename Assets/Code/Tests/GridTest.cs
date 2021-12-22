/* Tests the Grid2D class.
Attaches to an object and tests the grid to ensure functionality.
*/

using Byte.Grid;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Byte.Tests {
    public class GridTest : MonoBehaviour {
        [SerializeField] private Byte.Grid.Grid<int> grid;

        //Options Inspector
        [HorizontalGroup("Options")]
            [VerticalGroup("Options/LeftColumn")]
                [TitleGroup("Options/LeftColumn/Dimensions")]
                    [SerializeField] private bool displayDimensions = true;     
            [VerticalGroup("Options/RightColumn")]
                [TitleGroup("Options/RightColumn/CellCount")]
                    [SerializeField] private bool displayCellCount = true;
            [VerticalGroup("Options/RightColumn")]
                [TitleGroup("Options/RightColumn/Cell Size")]
                    [SerializeField] private bool displayCellSize = true;  

        private void Start() {
            grid = new Byte.Grid.Grid<int>(10,10);
            //Generate a 2D grid that is 20 by 20
            string outputText = "Grid Test: \n";

            if(displayDimensions){
                outputText += "Dimensions: " + grid.GetWidth() + ", " + grid.GetWidth() + "\n";
            }

            if(displayCellSize){
                outputText += "Cell Size: " + grid.GetCellSize() + "\n";
            }

            if(displayCellCount){
                outputText += "Cell Count: " + grid.GetCellCount() + "\n";
            }

        

            Debug.Log(outputText);
        }
    }
}