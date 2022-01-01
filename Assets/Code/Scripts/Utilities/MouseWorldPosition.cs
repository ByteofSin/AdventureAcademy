using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Byte.Utilities {
    public static class MouseWorldPosition {
        public static Vector3 GetMouseWorldPosition(){
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 999f)){
                return hit.point;
            } else {
                return Vector3.zero;
            }
        }
    }
}