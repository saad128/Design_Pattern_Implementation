using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Flyweight
{
    public class Flyweight 
    {
        private Data data;
        private float health;

        public Flyweight(Data data)
        {
            health = Random.Range(10f, 100f);
            this.data = data;
        }
    }
}