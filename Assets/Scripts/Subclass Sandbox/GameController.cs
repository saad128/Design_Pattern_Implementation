using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SubclassSandbox.Superpowers
{
    public class GameController : MonoBehaviour
    {
        private SkyLaunch skyLaunch;
        // Start is called before the first frame update
        void Start()
        {
            skyLaunch = new SkyLaunch();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                skyLaunch.Activate();
            }
        }
    }

}