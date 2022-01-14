using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

namespace Byte.Rpg {
    [CreateAssetMenu(fileName = "New Ability",
        menuName = "Ability",
        order = 0)]
    public class Ability : ScriptableObject {
        [Title("Texts")]
        public new string name;
        public string description;

        [Title("Attributes")]
        public int potency = 100;
        public int cooldown;
        public int turnTimer;
    }
}
