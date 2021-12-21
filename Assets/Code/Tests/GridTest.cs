/* Tests the Grid2D class.
Attaches to an object and tests the grid to ensure functionality.
*/

using Byte;
using UnityEngine;

namespace Byte.Tests {
    public class GridTest : MonoBehaviour {
        [Header("Grid Setup")]
        [SerializeField] private Grid grid;
        [Space]

        [SerializeField] private bool displayDimensions = true;
        [SerializeField] private bool vectorDimensions = true;

        private void Start() {
            //Generate a 2D grid that is 20 by 20
            string outputText = "Grid2D Test: \n";

            Debug.Log(outputText);
        }
    }
}