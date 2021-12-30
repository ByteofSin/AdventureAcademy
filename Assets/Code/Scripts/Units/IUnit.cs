using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Byte.Rpg {
    public interface IUnit {
        public void Move(); 
        public void UseAbility();
        public void Die();
        public void TakeDamage();
        public void AddStatMod();
        public void RemoveStatMod();
    }
}