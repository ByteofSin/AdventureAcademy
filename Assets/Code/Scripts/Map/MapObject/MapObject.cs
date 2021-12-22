using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Byte.Grid;

namespace Byte.Map {
    public abstract class MapObject : ScriptableObject {
        public new string name;
        public string description;
        public int x;
        public int y;
        public int z;
        public Grid<MapObject> gridReference;
    }
}