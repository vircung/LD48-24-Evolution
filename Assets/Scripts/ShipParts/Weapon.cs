using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Amunition;

namespace Assets.Scripts.ShipParts
{
    class Weapon : Hull
    {
        private GameObject projectilePrefab;

        public Weapon(Vector3 pos, Ship s)
            : base(pos, s)
        {
            prefab = Resources.Load("Prefabs/Weapon") as GameObject;
            projectilePrefab = Resources.Load("Prefabs/Amunition/Projectile1") as GameObject;

            direction = new Vector3(0.0f, 1.0f, 0.0f);
            type = HullTypes.Weapon;
        }

        public Vector3 direction { get; protected set; }

        public void Fire(Vector3 parentPosition)
        {
            Vector3 pos = parentPosition;
            //pos.z = 0.0f;
            //pos.x -= 0.5f;
            //pos.y += 0.5f;
            GameObject go = GameObject.Instantiate(projectilePrefab, pos + position, Quaternion.identity) as GameObject;
            ProjectileScript ps = go.GetComponent<ProjectileScript>();
            ps.SetDirection(direction);
        }
    }
}
