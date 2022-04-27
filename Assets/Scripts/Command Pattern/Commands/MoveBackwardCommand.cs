using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CommandPattern.RebineKey
{
    public class MoveBackwardCommand : Command
    {
        private MoveTheCube moveTheCube;

        public MoveBackwardCommand(MoveTheCube moveTheCube)
        {
            this.moveTheCube = moveTheCube;
        }

        public override void Execute()
        {
            moveTheCube.MoveBackward();
        }

        public override void Undo()
        {
            moveTheCube.MoveForward();
        }
    }
}