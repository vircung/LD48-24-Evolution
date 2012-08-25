using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Ship;

namespace Assets.Scripts.Amunition
{
	class Projectile
	{

        public Projectile()
        {
            prefab = Resources.Load("Prefabs/Amunition/Projectile1") as GameObject;
            speed = 5.0f;
        }

        public GameObject Launch(Weapon weapon){
            position = Vector3.zero;
            direction = weapon.direction;
            return prefab;
        }

        public GameObject prefab { get; protected set; }
        public ProjectileScript ps { get; protected set; }
        public Vector3 position { get; protected set; }
        public Vector3 direction { get; protected set; }
        public float speed { get; protected set; }

    }
}
