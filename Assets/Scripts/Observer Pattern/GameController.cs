using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ObserverPattern
{
    public class GameController : MonoBehaviour
    {
        public GameObject sphereObj;
        public GameObject box1Obj;
        public GameObject box2Obj;
        public GameObject box3Obj;

        Subject subject = new Subject();
        // Start is called before the first frame update
        void Start()
        {
            Box box1 = new Box(box1Obj, new JumpLittle());
            Box box2 = new Box(box2Obj, new JumpMedium());
            Box box3 = new Box(box3Obj, new JumpHigh());

            subject.AddObserver(box1);
            subject.AddObserver(box2);
            subject.AddObserver(box3);
        }

        // Update is called once per frame
        void Update()
        {
            if((sphereObj.transform.position).magnitude < 0.5f)
            {
                subject.Notify();
            }
        }
    }
}