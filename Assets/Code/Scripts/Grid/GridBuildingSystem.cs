using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Byte.Grid;
using Byte.Utilities;

namespace Byte.Grid {
    [RequireComponent(typeof(Byte.Map.Map))]
    public class GridBuildingSystem : MonoBehaviour {
        public Transform testTransform;
        
        public void Awake(){
        }

        public void Update(){
            if(Input.GetMouseButtonDown(0)){
                //Vector3 transformPosition = grid.GetWorldToGrid(MouseWorldPosition.GetMouseWorldPosition());

                //Instantiate(testTransform, transformPosition, Quaternion.identity);
            }
        }
        
    }
    
}