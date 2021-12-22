using UnityEngine;
using Sirenix.OdinInspector;

namespace Byte.Item {
    [CreateAssetMenu(fileName = "New Item",
        menuName = "Items/Item",
        order = 1)]
    public class Item : ScriptableObject {

        [TitleGroup("Descriptions")]
        [SerializeField]
        protected string description;

        public string GetName(){
            return name;
        }

        public string GetDescription(){
            return description;
        }
    }

}