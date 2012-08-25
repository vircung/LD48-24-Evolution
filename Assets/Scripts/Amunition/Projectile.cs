using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.ShipParts;

namespace Assets.Scripts.Amunition
{
	public class Projectile
	{

        public Projectile()
        {
            dmg = 3;
            speed = 10.0f;
        }
        
        public GameObject prefab { get; protected set; }
        public ProjectileScript ps { get; protected set; }
        public Vector3 position { get; protected set; }
        public Vector3 direction { get; protected set; }
        public float speed { get; set; }
        public int dmg { get; protected set; }
    }
}
