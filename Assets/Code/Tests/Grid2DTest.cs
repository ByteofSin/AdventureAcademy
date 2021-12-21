/* Tests the Grid2D class.
Attaches to an object and tests the grid to ensure functionality.
*/

using Byte.Grid;
using UnityEngine;

namespace Byte.Tests {
    public class Grid2DTest : MonoBehaviour {
        [Header("Grid Setup")]
        [SerializeField] private Grid2D grid;
        [Space]

        [Header("Test Options")]
        [Header("Dimensions")]
        [SerializeField] private bool displayDimensions = true;
        [SerializeField] private bool vectorDimensions = true;

        private void Start() {
            //Generate a 2D grid that is 20 by 20
            string outputText = "Grid2D Test: \n";

            //Get text for dimensions
            if(displayDimensions){
                outputText += "Dimensions: ";
                if(vectorDimensions){
                    Vector2 gridDimensions = grid.GetDimensions();
                    outputText += gridDimensions.x + ", " + gridDimensions.y;
                } else {
                    outputText += grid.GetWidth() + ", " + grid.GetHeight();
                }
            }


            Debug.Log(outputText);
        }
    }
}