using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class Ship
    {

        float speed = 1.0f;
        float maxSpeed = 20.0f;
        float minSpeed = 1.0f;
        float speedIncrease = 0.005f;
        
        public List<Hull> parts { get; set; }

        public Ship()
        {
            parts = new List<Hull>();

            parts.Add(new Hull(Vector3.zero));
            parts.Add(new Engine(new Vector3(0.0f, -1.0f, 0.0f)));
            parts.Add(new Weapon(new Vector3(1.0f, 0.0f, 0.0f)));
            parts.Add(new Weapon(new Vector3(-1.0f, 0.0f, 0.0f)));

        }

        public void Move(GameObject go, Vector3 dir)
        {
            Vector3 whereToMove = Vector3.zero;

            foreach (Hull part in parts)
            {
                if (part.type == HullTypes.Engine)
                {
                    Engine eng = part as Engine;

                    if (dir.y > 0 && (eng.direction & Directions.Up) == Directions.Up)
                    {
                        whereToMove.y += dir.y;
                    }

                    if (dir.y < 0 && (eng.direction & Directions.Down) == Directions.Down)
                    {
                        whereToMove.y += dir.y;
                    }
                    if (dir.x > 0 && (eng.direction & Directions.Right) == Directions.Right)
                    {
                        whereToMove.x += dir.x;
                    }
                    if (dir.x < 0 && (eng.direction & Directions.Left) == Directions.Left)
                    {
                        whereToMove.x += dir.x;
                    }
                }
            }

            go.transform.Translate(whereToMove * speed * Time.deltaTime);

            if (whereToMove != Vector3.zero)
                speed = Mathf.Lerp(speed, maxSpeed, speedIncrease);
            else
                speed = minSpeed;
        }

        public void DestroyPart(Hull part)
        {
            parts.Remove(part);
        }

        public void Fire(Vector3 position)
        {
            foreach (Hull part in parts)
            {
                if (part.type == HullTypes.Weapon)
                {
                    Weapon wpn = part as Weapon;
                    wpn.Fire(position);
                }
            }
        }
    }
}
