using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Ship
{
	class Weapon : Hull
	{
        public Weapon(Vector3 pos)
            : base(pos)
        {
            isProjectile = true;
            direction = new Vector3(0.0f, 1.0f, 0.0f);
            type = HullTypes.Weapon;
        }

        public Vector3 direction { get; protected set; }
    }
}
