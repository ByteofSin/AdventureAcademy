using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Byte.TileSystem {
    [CreateAssetMenu(menuName = "Tile",
        order = 0)]
    public class TileScriptableObject : ScriptableObject {
        public Transform model;
        public Material material;
    }    
}