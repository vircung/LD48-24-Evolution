using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ShipParts
{
    public class Hull
    {
        private float nextLevelRatio = 1.1f;
        private Ship ship;

        public Hull(Vector3 pos, Ship s)
        {
            prefab = Resources.Load("Prefabs/Hull") as GameObject;

            ship = s;
            position = pos;
            hp = 1;
            exp = 0;
            nextLevelExp = 10;
            level = 0;
            type = HullTypes.Hull;

        }

        public void TakeExp(int howMuch)
        {
            exp += howMuch;
            LevelUp();
        }

        public void TakeDamage(int howMuch)
        {
            hp -= howMuch;
            if (hp <= 0)
            {
                ship.DestroyPart(this);
            }
        }

        protected void LevelUp()
        {
            if (exp >= nextLevelExp)
            {
                exp -= nextLevelExp;
                level++;
                nextLevelExp = (int)(nextLevelExp * nextLevelRatio);
            }
        }

        public int hp { get; protected set; }
        public int exp { get; protected set; }
        public int nextLevelExp { get; protected set; }
        public int level { get; set; }

        public Vector3 position { get; protected set; }
        public GameObject prefab { get; protected set; }

        public HullTypes type { get; protected set; }


        internal void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
