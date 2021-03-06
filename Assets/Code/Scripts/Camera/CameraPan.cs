using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Byte.Camera {
    public class CameraPan : MonoBehaviour {
        public float speed;
        // Update is called once per frame
        void Update() {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            transform.position = new Vector3(
                transform.position.x + (h * speed),
                transform.position.y,
                transform.position.z + (v * speed));
            
        }
    }
}
