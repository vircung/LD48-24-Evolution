using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
	public class Enemy
	{
        public Enemy()
        {
            hp = 10;
            damage = 1;
        }

        public void TakeDamage(int howMuch)
        {
            hp -= howMuch;
            if (hp <= 0)
            {
                BadSpawner.Kill(this);
            }
        }

        public int damage { get; protected set; }
        public int hp { get; protected set; }
    }
}
