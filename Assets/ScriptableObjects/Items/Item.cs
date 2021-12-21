using UnityEngine;

namespace Byte.Item {
    public class Item : ScriptableObject {
        protected new string name;
        protected string description;

        public string GetName(){
            return name;
        }

        public string GetDescription(){
            return description;
        }
    }

}