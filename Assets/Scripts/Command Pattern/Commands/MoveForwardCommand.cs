using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CommandPattern.RebineKey
{
    public class MoveForwardCommand : Command
    {
        private MoveTheCube moveTheCube;

        public MoveForwardCommand(MoveTheCube moveTheCube)
        {
            this.moveTheCube = moveTheCube;
        }

        public override void Execute()
        {
            moveTheCube.MoveForward();
        }

        public override void Undo()
        {
            moveTheCube.MoveBackward();
        }
    }
}