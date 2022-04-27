using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CommandPattern.RebineKey
{
    public abstract class Command : MonoBehaviour
    {
        public abstract void Execute();

        public abstract void Undo();
    }
}