using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebineKey
{
    public class MoveTheCube : MonoBehaviour
    {
        [SerializeField] private const float moveStep = 1f;

        public void MoveForward()
        {
            Move(Vector3.forward);
        }
        public void MoveBackward()
        {
            Move(Vector3.back);
        }
        public void MoveRight()
        {
            Move(Vector3.right);
        }
        public void MoveLeft()
        {
            Move(Vector3.left);
        }

        private void Move(Vector3 direction)
        {
            transform.Translate(direction * moveStep);
        }


    }
}
