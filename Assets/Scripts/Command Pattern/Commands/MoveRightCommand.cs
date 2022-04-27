using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebineKey
{
    public class MoveRightCommand : Command
    {
        private MoveTheCube moveTheCube;

        public MoveRightCommand(MoveTheCube moveTheCube)
        {
            this.moveTheCube = moveTheCube;
        }

        public override void Execute()
        {
            moveTheCube.MoveRight();
        }

        public override void Undo()
        {
            moveTheCube.MoveLeft();
        }
    }
}