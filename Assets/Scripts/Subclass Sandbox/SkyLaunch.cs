using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SubclassSandbox.Superpowers
{
    public class SkyLaunch : SuperPower
    {
       public override void Activate()
        {
            PlaySound("Launch Sound");
            SpawnParticles("Dust");
            Move("The sky");
        }
    }

}