using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.ShipParts;

namespace Assets.Scripts
{
    public class Ship
    {
        public static int partId = 0;

        int size = 5;

        float speed = 1.0f;
        float maxSpeed = 20.0f;
        float minSpeed = 5.0f;
        float speedIncrease = 0.005f;

        public List<Hull> parts { get; set; }
        public Hashtable map;
        public Hashtable spots;

        public Ship()
        {
            parts = new List<Hull>();
            map = new Hashtable();

            parts.Add(new Hull(Vector3.zero, this));
            parts.Add(new Engine(new Vector3(0.0f, -1.0f, 0.0f), this));
            parts.Add(new Weapon(new Vector3(1.0f, 0.0f, 0.0f), this));
            parts.Add(new Weapon(new Vector3(-1.0f, 0.0f, 0.0f), this));

        }

        public void AddPart(GameObject go, Hull part)
        {
            map.Add(go, part);
        }

        #region TESTS
        private Vector2 FindFirstFreeSpot(HullTypes type)
        {
            return FindFirstFreeSpot(0, 0, type);
        }

        private Vector2 FindFirstFreeSpot(int x, int y, HullTypes type)
        {
            if (type == HullTypes.Weapon)
            {
                if (y + 1 <= size && !map.ContainsKey(new Vector2(x, y + 1)))
                {
                    return new Vector2(x, y + 1);
                }
                else if (x + 1 <= size && !map.ContainsKey(new Vector2(x + 1, y)))
                {
                    return new Vector2(x + 1, y);
                }
                else if (x - 1 >= -size && !map.ContainsKey(new Vector2(x - 1, y)))
                {
                    return new Vector2(x - 1, y);
                }
                return Vector2.zero;

            }
            else if (type == HullTypes.Hull)
            {
                if (y + 1 <= size && !map.ContainsKey(new Vector2(x, y + 1)))
                {
                    return new Vector2(x, y + 1);
                }
                else if (x + 1 <= size && !map.ContainsKey(new Vector2(x + 1, y)))
                {
                    return new Vector2(x + 1, y);
                }
                else if (x - 1 >= -size && !map.ContainsKey(new Vector2(x - 1, y)))
                {
                    return new Vector2(x - 1, y);
                }
                return Vector2.zero;

            }
            else
            { // ENGINE
                if (y - 1 >= -size && !map.ContainsKey(new Vector2(x, y - 1)))
                {
                    return new Vector2(x, y + 1);
                }
                else if (x + 1 <= size && !map.ContainsKey(new Vector2(x + 1, y)))
                {
                    return new Vector2(x + 1, y);
                }
                else if (x - 1 >= -size && !map.ContainsKey(new Vector2(x - 1, y)))
                {
                    return new Vector2(x - 1, y);
                }
                return Vector2.zero;
            }
        }
        #endregion

        public void DestroyPart(GameObject go)
        {
            (map[go] as Hull).Destroy();
            map.Remove(go);
            GameObject.Destroy(go);
        }

        public void DestroyPart(Hull part)
        {
            if (map.ContainsValue(part))
            {
                foreach (DictionaryEntry de in map)
                {
                    if (de.Value == part)
                    {
                        GameObject go = de.Key as GameObject;
                        DestroyPart(go);
                        return;
                    }
                }
            }
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
