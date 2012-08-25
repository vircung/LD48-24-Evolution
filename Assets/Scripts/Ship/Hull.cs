using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class Hull
    {
        public Hull(Vector3 pos)
        {
            prefab = Resources.Load("Prefabs/Hull") as GameObject;

            position = pos;
            hp = 1;
            mass = 1.0f;
            isProjectile = false;
            isEngine = false;
            type = HullTypes.Hull;

        }

        public int hp { get; protected set; }

        public bool isProjectile { get; protected set; }

        public bool isEngine { get; protected set; }

        public float mass { get; protected set; }

        public Vector3 position { get; protected set; }

        public HullTypes type { get; protected set; }

        public GameObject prefab { get; protected set; }
    }
}
