using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ShipParts;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
	class Exp : PwrUp
	{
        int amount = 5;
        GameObject parent;

        public Exp(GameObject par)
        {
            parent = par;
        }

        public void Give(Hull part)
        {
            part.TakeExp(amount);
        }

        public void Take(Hull part)
        {
            return;
        }

        public void Action(Hull part)
        {
            Give(part);
            GameObject.Destroy(parent);
        }
    }
}
