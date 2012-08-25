using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class Engine : Hull
    {
        public Engine(Vector3 pos)
            : base(pos)
        {
            isEngine = true;
            direction = new Vector3(0.0f, 1.0f, 0.0f);
            type = HullTypes.Engine;
        }

        public void Move()
        {
        }

        public Vector3 direction { get; protected set; }
    }
}
