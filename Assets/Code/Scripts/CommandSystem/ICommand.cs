using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Byte.Command {
    public interface ICommand {
        void Execute();
        void Undo();
    }
}