using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Byte.Utilities;
using Byte.Map;

namespace Byte.Grid {
    [RequireComponent(typeof(Byte.Map.GridMap))]
    public class GridBuildingSystem : MonoBehaviour {
        public Transform testTransform;
        private Byte.Map.GridMap map;

        public void Start(){
            map = GetComponent<Byte.Map.GridMap>();
        }

        public void Update(){
            if(Input.GetMouseButtonDown(0)){
                Vector3 mousePosition = MouseWorldPosition.GetMouseWorldPosition();
                Vector3 transformPosition = map.GetGrid().GetWorldToGrid(mousePosition);

                Instantiate(testTransform, transformPosition, Quaternion.identity);
            }
        }
        
    }
    
}