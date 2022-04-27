using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SubclassSandbox.Superpowers
{
    public abstract class SuperPower 
    {
        public abstract void Activate();

        protected void Move(string where)
        {
            Debug.Log($"Moving toward {where}");
        }

        protected void PlaySound(string sound)
        {
            Debug.Log($"Playing sound {sound}");
        }

        protected void SpawnParticles(string particles)
        {
            Debug.Log($"Firing {particles}");
        }
    }
}