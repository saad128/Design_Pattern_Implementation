using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CommandPattern.RebineKey
{
    public class MoveLeftCommand : Command
    {
        private MoveTheCube moveTheCube;

        public MoveLeftCommand(MoveTheCube moveTheCube)
        {
            this.moveTheCube = moveTheCube;
        }

        public override void Execute()
        {
            moveTheCube.MoveLeft();
        }

        public override void Undo()
        {
            moveTheCube.MoveLeft();
        }
    }
}