using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ShipParts
{
    public class Engine : Hull
    {
        public Engine(Vector3 pos, Ship s)
            : base(pos, s)
        {
            prefab = Resources.Load("Prefabs/Engine") as GameObject;

            direction = Directions.Left | Directions.Right | Directions.Up | Directions.Down;
            type = HullTypes.Engine;
        }

        public Directions direction { get; protected set; }
    }
}
