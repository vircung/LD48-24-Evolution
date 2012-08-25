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
            prefab = Resources.Load("Prefabs/Engine") as GameObject;

            isEngine = true;
            direction = Directions.Left | Directions.Right | Directions.Up | Directions.Down;
            type = HullTypes.Engine;
        }

        public Directions direction { get; protected set; }
    }
}
