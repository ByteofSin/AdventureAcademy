using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Byte.Command;

namespace Byte.Rpg {
    [RequireComponent(typeof(InputReader))]
    [RequireComponent(typeof(CommandProcessor))]
    public class Unit : MonoBehaviour {
        private InputReader inputReader;
        private CommandProcessor commandProcessor;

        private void Awake(){
            inputReader = GetComponent<InputReader>();
            commandProcessor = GetComponent<CommandProcessor>();
        }
    }
}