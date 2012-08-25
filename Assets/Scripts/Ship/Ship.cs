using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    class Ship
    {

        float speed = 1.0f;
        float maxSpeed = 20.0f;
        float minSpeed = 1.0f;
        float speedIncrease = 0.01f;

        public Ship()
        {

            prefab = Resources.Load("Prefabs/ShipPart") as GameObject;

            parts = new List<Hull>();

            parts.Add(new Hull(Vector3.zero));
            parts.Add(new Engine(new Vector3(0.0f, -1.0f, 0.0f)));
            parts.Add(new Weapon(new Vector3(0.0f, 1.0f, 0.0f)));


        }

        public void Move(GameObject go, Vector3 dir)
        {
            Vector3 whereToMove = Vector3.zero;

            foreach (Hull part in parts)
            {
                if (part.type == HullTypes.Engine)
                {
                    Engine eng = part as Engine;
                    bool condition = (eng.direction.x == dir.x && dir.x != 0.0f) || (eng.direction.y == dir.y && dir.y != 0.0f);
                    if (condition)
                    {
                        whereToMove += eng.direction;
                    }

                }
            }

            Debug.Log(whereToMove);

            go.transform.Translate(whereToMove * speed * Time.deltaTime);

            if (whereToMove != Vector3.zero)
                speed = Mathf.Lerp(speed, maxSpeed, speedIncrease);
            else
                speed = minSpeed;
        }

        public List<Hull> parts { get; protected set; }

        public GameObject prefab { get; protected set; }
    }
}
